    public class Product
    {
        public int id;
        public string url;
        public string otherData;
        public Product(int id, string url, string otherData)
        {
            this.id = id;
            this.url = url;
            this.otherData = otherData;
        }
        public Product ChangeProp(Product newProd)
        {
            this.url = newProd.url;
            this.otherData = newProd.otherData;
            return this;
        }
    }
