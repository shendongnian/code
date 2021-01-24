SubtitlesAnalysis ana = GetAnalysis();
string output = Newtonsoft.Json.JsonConvert.SerializeObject(input);
File.WriteAllText(@"D:\1.json", output);
and I **Deserialzed** it in .net framework:
var input = File.ReadAllText("D:\1.json");       
var ana = Newtonsoft.Json.JsonConvert.DeserializeObject<SubtitlesAnalysis>(input);
Class SubtitlesAnalysis :
    [Serializable()]
    public class SubtitlesAnalysis
    {
        public int WordCountOfBasic
        {
            get
            {
                return WordCountsByDifficulty[1];
            }
        }
        public int WordCountOfCet4
        {
            get
            {
                return WordCountsByDifficulty[2];
            }
        }
        public int WordCountOfCet6
        {
            get
            {
                return WordCountsByDifficulty[3];
            }
        }
        public int WordCountOfIeltsOrTofel
        {
            get
            {
                return WordCountsByDifficulty[4];
            }
        }
        public int WordCountOfGre
        {
            get
            {
                return WordCountsByDifficulty[5];
            }
        }
        public int WordCountOfGrePlus
        {
            get
            {
                return WordCountsByDifficulty[6];
            }
        }
        public int WordCount
        {
            get
            {
                return WordCountsByDifficulty[1] + WordCountsByDifficulty[2] + WordCountsByDifficulty[3] + WordCountsByDifficulty[4] + WordCountsByDifficulty[5] + WordCountsByDifficulty[6];
            }
        }
        private int[] _WordCountsByDifficulty = new int[8];
        public int[] WordCountsByDifficulty
        {
            get
            {
                return _WordCountsByDifficulty;
            }
        }
        public int IdiomCount { get; set; }
        public int Speed { get; set; }
        public TimeSpan Length { get; set; }
        public TimeSpan DialogueTime { get; set; }
        public List<WordIdWithContext> WordAndContext { get; set; } = new List<WordIdWithContext>();
        public List<WordIdWithContext> IdiomAndContext { get; set; } = new List<WordIdWithContext>();
        public List<WordWithContext> UnrecognisedWordsWithContext { get; set; } = new List<WordWithContext>();
        public SubtitlesAnalysis()
        {
        }
    }
