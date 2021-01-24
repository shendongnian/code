    public class BaseListProvider
    {
        public static readonly Bases Bun = new Bases() { BaseID = 1, BaseName = "Bun" };
        public static readonly Bases SeededBun = new Bases() { BaseID = 2, BaseName = "SeededBun" };
    
        public static IEnumerable<Bases> GetList()
        {
            return new[]
            {
                Bun,
                SeededBun
            };
        }
    }
    
    public class Bases
    {
        public int BaseID { get; set; }
        public string BaseName { get; set; }
    }
