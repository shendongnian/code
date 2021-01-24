        class Program
        {
            static void Main(string[] args)
            {
                Database j = new Database();
                var ds = j.DesignSets;
                List<Product> productsList = ds.Select(dsa => dsa.DesignSetAreas.Select(p => p.Products.Where(pr => (pr.ProductMods.Count == 0) && (pr.DeliveryCnt == 0))).SelectMany(x => x)).SelectMany(x => x).ToList();
                var productNames = productsList.GroupBy(x => x.Name).Select(x => x.ToList()).ToList();
            }
        }
        public class Database
        {
            public List<DesignSet> DesignSets { get; set; }
        }
        public class DesignSet
        {
            public List<DesignSetArea> DesignSetAreas { get; set; }
        }
        public class DesignSetArea
        {
            public List<Product> Products { get; set; }
        }
        public class Product
        {
            public List<string> ProductMods { get; set; }
            public int DeliveryCnt { get; set; }
            public string Name { get; set; }
        }
     
