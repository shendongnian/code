    public class NewClass
    {
        public OldClass MyClass { get; set; } //.NET 3.5 / VS2008
       
        private OldClass _oldClass; //.NET 2.0 / VS2005
        public OldClass MyClass
        {
           get { return _oldClass; }
           set { _oldClass = value; }
        }
    }
