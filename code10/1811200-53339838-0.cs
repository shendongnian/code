    public class Product : IEquatable<Product>
    {
        public int ID { get; }
        public string Name { get; }
        public decimal Currency { get; }
        public Product(int id, string name, decimal currency)
        {
            this.ID= id;
            this.Name=name;
            this.Currency=currency;
        }
        /// <summary>
        /// Converts a Product into a string description of itself.
        /// </summary>
        /// <returns>
        /// A <see cref="string"/> of the form <![CDATA["123 - ABC - 3.21"]]> with quantity, name and currency.
        /// </returns>
        public override string ToString() => $"{ID} - {Name} - {Currency}";
        /// <summary>
        /// Parses text into a Product.
        /// </summary>
        /// <param name="description">The description of the Product. Expecting the description 
        /// to be of the form <![CDATA["123 - ABC - 3.21"]]> with quantity, name and currency.</param>
        /// <returns>A new Product or null</returns>
        public static Product Parse(string description)
        {
            string[] parts = description.Split('-');
            if(parts.Length==3)
            {
                if(int.TryParse(parts[0].Trim(), out int id))
                {
                    string name = parts[1].Trim();
                    if(decimal.TryParse(parts[2].Trim(), out decimal currency))
                    {
                        return new Product(id, name, currency);
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            if(obj is Product product)
            {
                return Equals(product);
            }
            return false;
        }
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">A Product to compare with this Product.</param>
        public bool Equals(Product other)
        {
            return other!=null
                && ID==other.ID
                && Name==other.Name
                && Currency==other.Currency;
        }
        public override int GetHashCode()
        {
            int hashCode = 1486216620;
            hashCode=hashCode*-1521134295+ID.GetHashCode();
            hashCode=hashCode*-1521134295+EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode=hashCode*-1521134295+Currency.GetHashCode();
            return hashCode;
        }
    }
