    public class Item : IFormattable
    {
        public decimal Quantity;
        public string Name;
        public override string ToString(string format, IFormatProvider provider)
        {
            switch(format)
            {
                case "full":
                    return Name + Quantity;
                default:
                    return Name;
            }
        }
    }
