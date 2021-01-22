    public class Item : IFormattable
    {
        public string Name;
        public decimal Quantity;
        public string Unit;
        public override string ToString(string format, IFormatProvider provider)
        {
            switch(format)
            {
                case "quantity": return Quantity + Unit;
                default: return Name;
            }
        }
    }
