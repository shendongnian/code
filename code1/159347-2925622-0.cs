    class Percent
    {
        public Percent(double value)
        {
            this.value = value;
        }
        public double AsDouble()
        {
            return value;
        }
        public decimal AsDecimal()
        {
            return (decimal)value;
        }
        readonly double value;
    }
    static Percent ComputePercentage(ushort level, ushort capacity)
    {
        double percentage = 0;
        if (capacity == 1)
        {
            percentage = 1;
        }
        // calculations
        return new Percent(percentage);
    }
