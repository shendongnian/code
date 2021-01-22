    public struct Measure
    {
        public Measure(string unit, decimal quantity)
        {
            this.Unit = unit;
            this.Quantity = quantity;
        }
        public string Unit { get; private set; }
        public decimal Quantity { get; private set; }
        public override string ToString() 
        { 
            return string.Format("{0} {1}", this.Quantity, this.Unit);
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public Measure Measure { get; set; }
        public override string ToString() 
        { 
            return string.Format("{0}: {1}", this.Name, this.Measure);
        }
    }
