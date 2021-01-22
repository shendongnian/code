    using JetBrains.Annotations;
    class ClassSample
    {
        private string _name;
        private string _id;
        [UsedImplicitly]
        public string Name // Resharper believes this property is unused
        {
            get { return _name; }
        }
        [UsedImplicitly]
        public string ID // Resharper believes this property is unused
        {
            get { return _id; }
        }
        public ClassSample(string Name, string ID)
        {
            _name = Name;
            _id = ID;
        }
    }
