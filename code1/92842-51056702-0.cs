    public class LaxXamlReader : XamlReader
    {
        public override bool Read()
        {
            //Read once from the underlying reader
            _Reader.Read();
            //Check if current node is an unknown property
            while (NodeType == XamlNodeType.StartMember && Member.IsUnknown)
            {
                //We need to track member nesting level so that we can correctly
                //identify the corresponding EndMember node
                var level = 1;
                while (level > 0)
                {
                    _Reader.Read();
                    if (NodeType == XamlNodeType.StartMember)
                        level++;
                    else if (NodeType == XamlNodeType.EndMember)
                        level--;
                }
                //At this point we're at the corresponsing EndMember node, so we
                //advance to the next node; if it's also an unknown property, it
                //will be caught by the while loop
                _Reader.Read();
            }
            //If we've reached the end of input return false
            return !IsEof;
        }
        public override XamlReader ReadSubtree()
            => new LaxXamlReader(_Reader.ReadSubtree());
        protected override void Dispose(bool disposing)
        {
            //Only dispose the underlying reader if Dispose() was called;
            //otherwise let GC do the job
            if (disposing)
                ((IDisposable)_Reader).Dispose();
            base.Dispose(disposing);
        }
        //The code below simply forwards the functionality from the underlying reader
        public LaxXamlReader(XamlReader reader)
        {
            _Reader = reader;
        }
        private readonly XamlReader _Reader;
        public override bool IsEof => _Reader.IsEof;
        public override XamlMember Member => _Reader.Member;
        public override NamespaceDeclaration Namespace => _Reader.Namespace;
        public override XamlNodeType NodeType => _Reader.NodeType;
        public override XamlSchemaContext SchemaContext => _Reader.SchemaContext;
        public override XamlType Type => _Reader.Type;
        public override object Value => _Reader.Value;
        public override void Skip() => _Reader.Skip();
    }
