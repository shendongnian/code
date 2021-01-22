    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string FavoriteColor { get; set; }
        // probably a better way to do this
        // just writing fast for demo
        public XElement ToXElement()
        {
            List<XAttribute> attributes = new List<XAttribute>();
            if (this.CustomerId != 0)
                attributes.Add(new XAttribute("CustomerId", this.CustomerId));
            if (this.Name != null)
                attributes.Add(new XAttribute("Name", this.Name));
            if (this.FavoriteColor != null)
                attributes.Add(new XAttribute("FavoriteColor", this.FavoriteColor));
            XElement result = new XElement("Customer", attributes);
            return result;
        }
    }
