    class ExampleModel
    {
        public string NameProperty { get; set; }
        public string OtherProperty { get; set; }
        public object DifferentProperty { get; set; }
        
        public string DifferentPropertyString { get; set; }
        public string[] DifferentPropertyStringArray { get; set; }
        public int DifferentPropertyInt { get; set; }
        private void ResolveDifferentProperty()
        {
            // Try to resolve the DifferentProperty property with a converter or 
            //something similar into one of your three specific "DifferentProperty"'s?
        }
    }
    class Program
    {
        public void Main(string[] args)
        {
            var model = JsonConvert.DeserializeObject<ExampleModel>(jsonData);
            model.ResolveDifferentProperty();
        }
    }
