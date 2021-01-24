       class Program
    {
        static void Main(string[] args)
        {
            var p = new List<Product>();
            p.Add(new Product() { Id = 1, Specs = new List<Spec>() { new Spec() { Id = 90, IsActive = true }, new Spec() { Id = 91, IsActive = false } } });
            p.Add(new Product() { Id = 2, Specs = new List<Spec>() { new Spec() { Id = 92, IsActive = false }, new Spec() { Id = 93, IsActive = false } } });
            p.Add(new Product() { Id = 3, Specs = new List<Spec>() { new Spec() { Id = 94, IsActive = true}, new Spec() { Id = 95, IsActive = true} } });
            var products = p.Where(x => x.Specs.Any(a => a.IsActive)).ToList();
    //products ids (1 and 3)
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Spec> Specs { get; set; }
    }
    public class Spec
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual Product Product { get; set; }
    }
