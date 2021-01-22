    public struct Measure
    {
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public override string ToString() 
        { 
            return string.Format("{0} {1}", this.Quantity, this.Unit);
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public Measure Measure { get; set; }
    }
