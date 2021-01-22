    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ////Calısan calisan = new Calısan() { ID = 1, Ad = "yusuf", SoyAd = "karatoprak" };
                MyCalısan myCalısan = new MyCalısan();
                //option 1:
                //==========
                myCalısan.list.AddRange(new[] { new Calısan() { ID = 1, Ad = "yusuf", SoyAd = "karatoprak" }, new Calısan() { ID = 2, Ad = "blah", SoyAd = "jiggy" } });
                //option 2:
                //=========
                myCalısan.list.AddRange(new[] { new Calısan(1, "yusuf", "karatoprak"), new Calısan(2, "blah", "jiggy") });
                ////myCalısan.list.Add(calisan);
                foreach (Calısan item in myCalısan.list)
                {
                    Console.WriteLine(item.Ad.ToString());
                }
                Console.ReadKey();
            }
        }
        public class Calısan
        {
            public Calısan() { }
                                public Calısan(int id, string ad, string soyad)
        {
            ID = id;
            Ad = ad;
            SoyAd = soyad;
        }
            public int ID { get; set; }
            public string Ad { get; set; }
            public string SoyAd { get; set; }
        }
        public class MyCalısan
        {
            public List<Calısan> list { get; set; }
            public MyCalısan()
            {
                list = new List<Calısan>();
            }
        }
    }
