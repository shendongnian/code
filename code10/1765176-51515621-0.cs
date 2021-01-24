    public class House
    {
        public string Road { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<House> list1 = new List<House>();
            List<House> list2 = new List<House>();
            var sample = 50000;
            for (int i = 0; i < sample; i++)
            {
                if (i % 3 == 0)
                {
                    list1.Add(new House() {Road = "Adam Road 1"});
                    list2.Add(new House() {Road = "Adam Road 1"});
                }
                else
                {
                    list1.Add(new House(){Road = "Random"});
                    list2.Add(new House(){Road = "Random"});   
                }
            }
        
            Console.WriteLine("Test " + sample + " samples:");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            list1.ForEach(l =>
            {
                if (l.Road.Contains("Adam Road")) l.Road = "Adams Road";
            });
            sw.Stop();
            Console.WriteLine("1 - ForEach: " + sw.ElapsedMilliseconds + " ms");
            
            sw.Reset();
            sw.Start();
            list2.Where(l=> l.Road.Contains("Adam Road")).ToList().ForEach(l =>
            
                l.Road = "Adams Road"
            );
            sw.Stop();
            Console.WriteLine("2 - Where.ToList.ForEach: " + sw.ElapsedMilliseconds + " ms");
        }
    }
