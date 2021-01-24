    class Program
    {
        static void Main(string[] args)
        {
            List<string> wordsToCut = File.ReadAllLines("text2.txt").Distinct().ToList();
            List<UniqueWord> uniqueWords = new List<UniqueWord>();
            foreach (string word in File.ReadAllLines("text1.txt"))
            {
                if (wordsToCut.Contains(word) == false)
                {
                    UniqueWord uniqueWord = uniqueWords.Where(x => x.Word == word).FirstOrDefault();
                    if (uniqueWord != null)
                    {
                        uniqueWord.Occurrence++;
                    }
                    else
                    {
                        uniqueWords.Add(new UniqueWord(word));
                    }
                }
            }
            uniqueWords = uniqueWords.OrderByDescending(x => x.Word.Length).Take(10).ToList();
        }
    }
    public class UniqueWord
    {
        public string Word { get; set; }
        public int Occurrence { get; set; }
        public UniqueWord(string word)
        {
            Word = word;
            Occurrence = 1;
        }
    }
