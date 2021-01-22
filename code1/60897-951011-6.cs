    public class Product
    {
        private Manufacturer m_manufacturer;
    
        internal Manufacturer Manufacturer
        {
            get { return m_manufacturer; }
            set { m_manufacturer = value; }
        }
    }
    
    public class Manufacturer
    {
        private List<Product> m_Products = new List<Product>();
    
        public IEnumerable<Product> Products { get { return m_Products.AsReadOnly(); } }
    
        public void AddProduct( Product p )
        {
            if( !m_Products.Contains( p ) )
            {
                m_Products.Add( p );
                p.Manufacturer = this;
            }
        }
    
        public void RemoveProduct( Product p )
        {
            m_Products.Remove( p );
            p.Manufacturer = null;
        }
    }
