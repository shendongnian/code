    public class Song
    {
        public string Name { get; }
    
        public string Artist { get; }
    
        public int Records { get; }
    
        public Song(string name, string artist, int records)
        {
            Name = name;
            Artist = artist;
            Records = records;
        }
    }
    
    public interface IInOutService
    {
        void Ask(string question);
    
        string GetString();
    
        string AskValue(string question);
    }
    
    public class InOutService : IInOutService
    {
        public void Ask(string question)
        {
            Console.WriteLine(question);
        }
    
        public string GetString()
        {
            return Console.ReadLine();
        }
    
        public string AskValue(string question)
        {
            Ask(question);
            return GetString();
        }
    }
    
    public class FactorySong
    {
        private readonly IInOutService _inOutService;
    
        public FactorySong(IInOutService inOutService)
        {
            _inOutService = inOutService;
        }
    
        public Song Create()
        {
            var name = _inOutService.AskValue("What is the name of your song");
            var artist = _inOutService.AskValue("What is the artists name");
    
            int records;
            _inOutService.Ask("How many records did it sell");
    
            while (!int.TryParse(_inOutService.GetString(), out records) || records < 0)
            {
                _inOutService.Ask("That is not valid please enter a number");
            }
    
            return new Song(name, artist, records);
        }
    }
    
    [TestClass]
    public class FactorySongTest
    {
        [TestMethod]
        public void TestCreate()
        {
            var consoleService = Substitute.For<IInOutService>();
            var testString = "test";
            var testRecords = 1;
    
            consoleService.AskValue(Arg.Any<string>()).Returns(testString);
            consoleService.GetString().Returns(testRecords.ToString());
    
            var factory = new FactorySong(consoleService);
            var song = factory.Create();
    
            Assert.IsNotNull(song);
            Assert.IsTrue(testString == song.Name);
            Assert.IsTrue(testString == song.Name);
            Assert.AreEqual(testRecords, song.Records);
        }
    }
