    class Program
        {
            static void Main(string[] args)
            {
                Random r = new Random();
    
                List<Chingamajig> chinga = new List<Chingamajig>();
                string[] verylongnum = new string[] { "00000000002312312", "34234002342342" };
                int[] somenum = new int[] { 7, 14, 12, 28 };
    
                for(int i = 0;i<100;i++)
                {
                    Chingamajig c = new Chingamajig();
    
                    c.VeryLongNumbers = verylongnum[r.Next(0, 2)];
                    c.DateValue = DateTime.Now.AddMinutes((double)r.Next(-100, 101));
                    c.SomeNumber = somenum[r.Next(0, 4)];
                    chinga.Add(c);
                }
    
                foreach (Chingamajig c in chinga.OrderBy(x => x.VeryLongNumbers).ThenBy(y => y.DateValue).ThenBy(z => z.SomeNumber))
                {
                    Console.WriteLine("{0} : {1} : {2}", c.VeryLongNumbers, c.DateValue, c.SomeNumber);
                }
    
                var m = "00000000002312312";
                var dt = DateTime.Now.Date;
                var interval = 2;
    
                var ee = chinga.Where(x => (x.VeryLongNumbers == m) && (x.DateValue >= dt)).AsEnumerable()
                    .Select((z, i) => new { MSN = z.VeryLongNumbers, PingDT = z.DateValue, PingV = z.SomeNumber, i = i })
                    .Where(x => x.i % interval == 0).ToList();
    
                Console.Clear();
    
                foreach(var n in ee)
                {
                    Console.WriteLine("{0} : {1} : {2} : {3}", n.MSN, n.PingDT, n.PingV, n.i);
                }
    
                Console.ReadLine();
            }
        }
    
        public class Chingamajig
        {
            public string VeryLongNumbers { get; set; }
            public DateTime DateValue { get; set; }
            public int SomeNumber { get; set; }
        }
