    [table("NameTable")]
    public class Transducer
    {
        //Name is the ID
        [Key] //is Key from table
        public string Name { get; set; }
        public double Gain { get; set; }
        public double Offset { get; set; }
        public double RawValue { get; set; }
        public double ScaledValue { get; private set; }
        public double CalculateScaledValue(double RawValue)
        {
            ScaledValue = (Gain * RawValue) + Offset;
            return ScaledValue;
        }
    }
