    public class UriAnsiStringType : UriType
    {
        public UriAnsiStringType()
            : base(new AnsiStringSqlType())
        { }
        public override string Name
        {
            get { return "UriAnsiStringType"; }
        }
    } 
