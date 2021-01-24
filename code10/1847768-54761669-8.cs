        public static string[] CreateRandomWords(int count)
        {
            string[] result = new string[count];
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);
                result[i] = finalString;
            }
            return result;
        }
        public class Bigram
        {
            public string Phrase { get; set; }
            public int Count { get; set; }
        }
        public static List<Bigram> GetSequenceA1(string[] words)
        {
            List<Bigram> bigrams = new List<Bigram>();
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (string.IsNullOrWhiteSpace(words[i]) == false)
                {
                    Bigram bigram = new Bigram()
                    {
                        Phrase = words[i] + " " + words[i + 1]
                    };
                    bigrams.Add(bigram);
                    var matches = bigrams.Where(p => p.Phrase == bigram.Phrase).Count();
                    if (matches == 0)
                    {
                        bigram.Count = 1;
                        bigrams.Add(bigram);
                    }
                    else
                    {
                        int bigramToEdit =
                            bigrams.IndexOf(
                                bigrams.Where(b => b.Phrase == bigram.Phrase).FirstOrDefault());
                        bigrams[bigramToEdit].Count += 1;
                    }
                }
            }
            return bigrams;
        }
        public static List<Bigram> GetSequenceA2(string[] words)
        {
            List<Bigram> bigrams = new List<Bigram>();
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (string.IsNullOrWhiteSpace(words[i]) == false)
                {
                    Bigram bigram = new Bigram()
                    {
                        Phrase = words[i] + " " + words[i + 1]
                    };
                    bigrams.Add(bigram);
                    var match = bigrams.FirstOrDefault(b => b.Phrase == bigram.Phrase);
                    if (match == null)
                    {                        
                        bigram.Count = 1;
                        bigrams.Add(bigram);
                    }
                    else
                    {                        
                        match.Count += 1;
                    }
                }
            }
            return bigrams;
        }
        public static List<Bigram> GetSequenceB(string[] words)
        {
            List<Bigram> bigrams = new List<Bigram>();
            IDictionary<string, int> bigramsDict = new Dictionary<string, int>();
            for (int i = 0; i < words.Length - 1; i++)
            {
                if (string.IsNullOrWhiteSpace(words[i]))
                {
                    continue;
                }
                string key = words[i] + " " + words[i + 1];
                if (!bigramsDict.ContainsKey(key))
                    bigramsDict.Add(key, 1);
                else
                    bigramsDict[key]++;
            }
            foreach (var item in bigramsDict)
            {
                bigrams.Add(new Bigram { Phrase = item.Key, Count = item.Value });
            }
            return bigrams;
        }
        public static void Run()
        {
            string[] _wordsList = CreateRandomWords(85000);
            Stopwatch stopwatchA1 = new Stopwatch();
            stopwatchA1.Start();
            List<Bigram> SequenceA1 = GetSequenceA1(_wordsList);
            stopwatchA1.Stop();
            double durationA1 = stopwatchA1.Elapsed.TotalMilliseconds;
            Console.WriteLine("SequenceA1:" + durationA1);
            Stopwatch stopwatchA2 = new Stopwatch();
            stopwatchA2.Start();
            List<Bigram> SequenceA2 = GetSequenceA2(_wordsList);
            stopwatchA2.Stop();
            double durationA2 = stopwatchA2.Elapsed.TotalMilliseconds;
            Console.WriteLine("SequenceA2:" + durationA2);
            Stopwatch stopwatchB = new Stopwatch();
            stopwatchB.Start();
            List<Bigram> SequenceB = GetSequenceB(_wordsList);
            stopwatchB.Stop();
            double durationB = stopwatchB.Elapsed.TotalMilliseconds;
            Console.WriteLine("SequenceB:" + durationB);
        }
