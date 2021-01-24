    public class Song
    {
        public string Name { get; }
        public decimal Price { get; }
        public string Owner { get; }
        public int Id { get; }
    
        public Song(string name, decimal price, string owner, int id)
        {
            this.Name = name;
    		this.Price = price;
    		this.Owner = owner;
    		this.Id = id;
        }
    }
