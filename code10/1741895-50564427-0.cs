    public class Row
    {
        public int Val1 { get; set; }
    
        public int Val2 { get; set; }
    
        public int Val3 { get; set; }
    
        public decimal Val4
        {
            get
            {
                return (decimal)Val3 / (Val2 + (decimal)Val3) *100;
            }
        }
    }
