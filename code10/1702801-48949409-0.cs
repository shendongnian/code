    class Program
    {
        static void Main(string[] args)
        {
            var bm = new BirdModel();
            bm.BirdFils = new List<BirdFile>
            {
                new BirdFile {ID = 1, Name = "Bird A"},
                new BirdFile {ID = 2, Name = "Bird B"}
            };
            bm.BirdFils.ToList().ForEach(x => Console.WriteLine($"Name: {x.Name}, ID: {x.ID}"));
            Console.ReadKey();
        }
    }
    public class BirdModel
    {
        public IEnumerable<BirdFile> BirdFils { get; set; }
    }
    public partial class BirdFile
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
