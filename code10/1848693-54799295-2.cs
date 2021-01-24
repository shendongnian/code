    public class CalculatedItem
    {
        public string Column1 { get; }
        public string Column2 { get; }
        public decimal Calculated { get; }
        public CalculatedItem(Item item, decimal maxValue)
        {
            Column1 = item.Column1;
            Column2 = item.Column2;
            Calculated = (decimal)item.Column3 / maxValue
        }
    } 
