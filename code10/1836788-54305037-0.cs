    class Father
    {
        public List<Child> Children { get; } = new List<Child>();
    }
    class Child
    {
        public Father Father { get; set; }
    }
