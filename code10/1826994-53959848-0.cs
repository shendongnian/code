    public class ufloat
    {
        public float value { get; }
        public ufloat(int val) {  value = Math.Abs(val); }
        public static implicit operator ufloat(int input) 
        {
             return new ufloat(input);
        }
    }
