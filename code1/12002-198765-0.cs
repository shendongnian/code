        public class BetterXmlTextWriter : XmlTextWriter
        {
            public BetterXmlTextWriter(TextWriter w)
                : base(w)
            {
            }
            public override void WriteFullEndElement()
            {
                base.WriteEndElement();
            }
        }
