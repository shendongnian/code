        private static void Main(string[] args)
        {
            var someText = $"aasdlj{Environment.NewLine}aksdlkajsdlkasldj{Environment.NewLine}asld{Environment.NewLine}jkalskdjasldjlasd";
            List<long> listOfLineBreakLocations = GetLineBreaksParallel(Encoding.ASCII.GetBytes(someText));
            foreach (var index in listOfLineBreakLocations)
            {
                Console.WriteLine($"found NewLine at position '{index}'");
            }
            Console.ReadKey();
        }
        private static List<long> GetLineBreaksParallel(byte[] someText)
        {
            var list = new List<long>();
            Parallel.For(0, someText.LongLength, (i) =>
            {
                if (someText[i] == '\n') //check for line break
                {
                    lock (list) //lock list to ensure data integrity
                    {
                        list.Add(i); //add index to list
                    }
                }
            });
            return list;
        }
