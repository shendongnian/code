    public class MyControl : Control
    {
        public class SomeOptions
        {
            public string Option1 { get; set; }
            public string Option2 { get; set; }
        }
    
        [DesignerSerializationVisiblity(DesignerSerializationVisibility.Content)]
        public SomeOptions Options { get; private set; }
    
        public string Foo { get; set; }
    }
