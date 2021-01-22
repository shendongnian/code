    public class IntelligentNumber
    {
        private readonly double number;
        public IntelligentNumber(double number)
        {
            this.number = number;
        }
        public override string ToString()
        {
            long integralPart = (long)this.number;
            if((double)integralPart == this.number)
            {
                return integralPart.ToString();
            }
            else
            {
                return this.number.ToString();
            }
        }
    }
