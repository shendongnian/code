    public class Fragrance : IFragrance
    {
        private readonly string name;
     
        public Fragrance(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
     
            this.name = name;
        }
     
        public string Spread()
        {
            return this.name;
        }
    }
