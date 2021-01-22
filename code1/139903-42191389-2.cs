    internal class MyAttribute : Attribute
    {
        public string Name { get; set; }
        public MyAttribute(string name)
        {
            Name = name;
        }
    }
