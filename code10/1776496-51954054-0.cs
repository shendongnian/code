    public class Screen : IScreen
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AnotherCustomCollection<IBaseField> Fields { get; set; }
        CustomCollection<IField> ITable.Fields
        {
            get
            {
                throw new System.NotSupportedException();
            }
        }
    }
