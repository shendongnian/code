    public class MyListObject
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public MyListObject(string name, string path)
        {
            Path = path;
            Name = name;
        }
        // to nicely display it in List Box
        public override string ToString()
        {
            return Name + " " + Path;
        }
    }
