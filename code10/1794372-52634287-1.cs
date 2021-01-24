    class Program
    {
        static void Main(string[] args)
        {
            var p = new List<Product>();
            p.Add(new Product() { Id = 1, Specs = new List<Spec>() { new Spec() { Id = 90, IsActive = true }, new Spec() { Id = 91, IsActive = false } } });
            p.Add(new Product() { Id = 2, Specs = new List<Spec>() { new Spec() { Id = 92, IsActive = false }, new Spec() { Id = 93, IsActive = false } } });
            p.Add(new Product() { Id = 3, Specs = new List<Spec>() { new Spec() { Id = 94, IsActive = true}, new Spec() { Id = 95, IsActive = true} } });
            p.Add(new Product() { Id = 4, Specs = new List<Spec>() { new Spec() { Id = 96, IsActive = true }, new Spec() { Id = 97, IsActive = true } } });
            //Brings Products with ALL Spec.IsActive True
            var products = p.Where(x => x.Specs.All(a => a.IsActive)).ToList();
            Console.WriteLine("ALL ->" + string.Join(",", products.Select(pro => pro.Id.ToString()).ToArray()));
            //result is 3,4
            //Brings Products with ANY Spec.IsActive True
            var products2 = p.Where(x => x.Specs.Any(a => a.IsActive)).ToList();
            Console.WriteLine("ANY ->" + string.Join(",", products2.Select(pro => pro.Id.ToString()).ToArray()));
            //result is 1,3,4
            Console.ReadLine();
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
