    public class MyFile
    {
        public string Name;
        public bool isOpen;
        public MyFile(string name)
        {
            Name = name;
            isOpen = false;
        }
    }
    List<MyFile> lsf = new List<MyFile>()
    {
        new MyFile("test0"),
        new MyFile("test1"),
        new MyFile("test2"),
        new MyFile("test3"),
        new MyFile("test4")
    };
