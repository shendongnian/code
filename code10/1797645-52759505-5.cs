        private static void Main(string[] args)
        {
            var someText = $"aasdlj{Environment.NewLine}aksdlkajsdlkasldj{Environment.NewLine}asld{Environment.NewLine}jkalskdjasldjlasd";
            var data = Encoding.ASCII.GetBytes(someText);
            var c = '\n';
            var listOfLineBreakLocations = FindAllInString(data, c);
            foreach (var index in listOfLineBreakLocations)
            {
                Console.WriteLine($"found NewLine at position '{index}'");
            }
            Console.ReadKey();
        }
        private static List<long> FindAllInString(byte[] someText,char c)
        {
            var list = new List<long>();
            Parallel.For(0, someText.LongLength, (i) =>
            {
                if (someText[i] == c) //check for line break
                {
                    lock (list) //lock list to ensure data integrity
                    {
                        list.Add(i); //add index to list
                    }
                }
            });
            return list;
        }
