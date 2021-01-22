    public class Percentage
    {
        public static readonly double MinValue = 0.0;
        public static readonly double MaxValue = 100.0;
        private double value;
        public double Value
        {
           get { return this.value; }
           set
           {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentOutOfRangeException("...");
                }
                this.value = value;
           }
    }
