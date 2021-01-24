    public class MyClassMetadata
    {
        [DisplayName("Name Property")]
        public string Name { get; set; }
        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor," +
            "System.Design, Version=2.0.0.0, Culture=neutral, " + 
            "PublicKeyToken=b03f5f7f11d50a3a",
            typeof(System.Drawing.Design.UITypeEditor))]
        public List<string> List { get; set; }
    }
