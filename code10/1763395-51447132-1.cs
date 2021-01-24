    public class PropertyCopyPair
    {
        public PropertyCopyPair(string name, Type theType, MethodInfo sourceReader, MethodInfo destWriter)
        {
            PropertyName = name;
            TheType = theType;
            SourceReader = sourceReader;
            DestWriter = destWriter;
        }
        public string PropertyName { get; set; }
        public Type TheType { get; set; }
        public MethodInfo SourceReader { get; set; }
        public MethodInfo DestWriter { get; set; }
    }
