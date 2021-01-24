    class Program
    {
        static void Main(string[] args)
        {
            const int I = 15;
            try
            {
                //init first list
                List<Lst1> Lst1_ = new List<Lst1>();
                Init(Lst1_);
                
                //print it
                Console.WriteLine("Lst1_");
                Console.WriteLine(new string('-', I));
                Lst1_.ForEach(x => Console.WriteLine(x.PropertyList()));
                Console.WriteLine(new string('=', I));
                Console.ReadKey();
                //init second list
                List<Lst1> Lst2_ = Lst1_.Cast<Lst1>().ToList(); //equivalent of two next lines
                //List<Lst1> Lst2_ = new List<Lst2>().ConvertAll(x => (Lst1)x);
                //Lst2_.AddRange(Lst1_);
                
                //add one more
                Lst2_.Add(new Lst2
                {
                    filed1 = "101",
                    filed2 = 202,
                    filed100 = true,
                    filed101 = "10100"
                });
                
                //and print 
                Console.WriteLine("Lst2_");
                Console.WriteLine(new string('-', I));
                Lst2_.ForEach(x => Console.WriteLine(x.PropertyList()));
                Console.WriteLine(new string('=', I));
                Console.ReadKey();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
        private static void Init(List<Lst1> lst_)
        {
            for (int i = 1; i <= 3; i++)
            {
                lst_.Add(new Lst1
                {
                    filed1 = i.ToString(),
                    filed2 = 2 * i,
                    filed100 = i % 2 == 0
                });
            }
        }
    }
