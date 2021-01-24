    public class FakeFileReader : IFileReader
    {
        public Dictionary<string, string[]> Files { get; }
        public FakeFileReader ()
        {
            Files = new Dictionary<string, string[]>();
        }
        public string[] ReadAllLinesFrom(string path)
        {
            return Files.GetValueOrDefault(path);
        }        
    }
