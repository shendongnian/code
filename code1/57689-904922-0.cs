    [Serializable]
    class Test
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    [Serializable]
    class Transport
    {
        public Transport()
        {
            this.Items = new List<Test>();
        }
        public IList<Test> Items { get; private set; }
    }
