       class Program
        {
            static void Main(string[] args)
            {
                var data = new DateTime[] { new DateTime(2018, 09, 01), new DateTime(2018, 08, 11) };
                var query = data.Where(x => x.Date.ToString("D").Contains("Aug"));
                foreach (var dat in query)
                {
                    Console.WriteLine(dat);
                }
                Console.ReadKey();
            }
        }
