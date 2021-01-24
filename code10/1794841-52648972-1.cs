    public class Product
    {
        public Product()
        {
        }
        public Product(List<Sqs> properties)
        {
            Id = (int)properties[0].Value;
            Name = (string)properties[1].Value;
            Manufacturer = (string)properties[2].Value;
            Keywords = (string)properties[3].Value;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Keywords { get; set; }
        public string ProductText => $"({Id}) {Name}";
        public override string ToString() => ProductText;
    }
