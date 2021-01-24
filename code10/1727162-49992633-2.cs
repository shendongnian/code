    public class Something
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public List<string> stringList { get; set; }
        public Something (uint id, string name)
        {
            Id = id;
            Name = name;
            stringList = new List<string>();
            for(long i = 0; i < 10000; i++)
            {
                stringList.Add(i.ToString());
            }
        }
        
    }
