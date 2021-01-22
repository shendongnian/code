    public class DecimalRandom : Random
        {
            public override decimal NextDecimal()
            {
                //The low 32 bits of a 96-bit integer. 
                int lo = this.Next(int.MinValue, int.MaxValue);
                //The middle 32 bits of a 96-bit integer. 
                int mid = this.Next(int.MinValue, int.MaxValue);
                //The high 32 bits of a 96-bit integer. 
                int hi = this.Next(int.MinValue, int.MaxValue);
                //The sign of the number; 1 is negative, 0 is positive. 
                bool isNegative = (this.Next(2) == 0);
                //A power of 10 ranging from 0 to 28. 
                byte scale = Convert.ToByte(this.Next(29));
    
                Decimal randomDecimal = new Decimal(lo, mid, hi, isNegative, scale);
    
                return randomDecimal;
            }
        }
