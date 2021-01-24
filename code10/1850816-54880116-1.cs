    public class BaseListProvider : IBaseListProvider
    {
        public static readonly Bases Bun = new Bases() { BaseID = 1, BaseName = "Bun" };
        public static readonly Bases SeededBun = new Bases() { BaseID = 2, BaseName = "SeededBun" };
    
        public IEnumerable<Bases> GetList()
        {
            return new[]
            {
                Bun,
                SeededBun
            };
        }
    }
    
    public interface IBaseListProvider
    {
        IEnumerable<Bases> GetList();
    }
    
    public class Bases
    {
        public int BaseID { get; set; }
        public string BaseName { get; set; }
    }
