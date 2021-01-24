    public class Company
    {
        public int id { get; set }
        public virtual ICollection<Sevice> Services { get; set; }
        public virtual ICollection<Container> Containers { get; set; }
    }
    
    public class Container
    {
        public int id { get; set; }
        public int id_company { get; set; }
        public virtual Company company { get; set; }
        public virtual ICollection<Sevice> Services { get; set; }
    }
    
    public class Sevice
    {
        public int id { get; set; }
        public int id_company { get; set; }
        public int id_container { get; set; }
        public virtual Company company { get; set; }
        public virtual Container container { get; set; }
    }
