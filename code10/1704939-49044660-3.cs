    public class MileStone
    {
        public int CheckPoint { get; set; }
        public decimal Distance { get; set; }
        public override string ToString()
        {
            return Distance.ToString();
        }
    }
