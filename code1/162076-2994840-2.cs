    public struct Container
    {
        public string String1 { get; private set; }
        public int Int1 { get; private set; }
        public int Int2 { get; private set; }
        public Container(string string1, int int1, int int2)
            : this()
        {
            this.String1 = string1;
            this.Int1 = int1;
            this.Int2 = int2;
        }
    }
    //Client code
    IList<Container> myList = new List<Container>();
    myList.Add(new Container("hello world", 10, 12));
