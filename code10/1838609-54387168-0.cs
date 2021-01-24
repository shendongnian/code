     class TestT211
    {
        static void Main(string[] args)
        {
            FileReaderBuilder.New.Open(@"C:\file.txt").Read();
        }
    }
    public class ReadTheFile
    {
        private int _lineCounter = 0;
        private string _lineOfText;
        public StreamReader Open(string path)
        {
            return new StreamReader(path);
        }
        public void Read(StreamReader sr)
        {
            while ((_lineOfText = sr.ReadLine()) != null)
            {
                Console.WriteLine(_lineOfText);
            }
        }
    }
    public class FileReaderBuilder
    {
        private readonly ReadTheFile _file;
        private StreamReader _streamReader;
        private FileReaderBuilder()
        {
            _file = new ReadTheFile();
        }
        public FileReaderBuilder Open(string path)
        {
             _streamReader = _file.Open(path);
            return this;
        }
        public FileReaderBuilder Read()
        {
            if (_streamReader == null)
            {
                throw new ArgumentNullException(nameof(_streamReader));
            }
            _file.Read(_streamReader);
            return this;
        }
        public static FileReaderBuilder New => new FileReaderBuilder();
    }
