    interface IAbleToGetAverage 
    {
        double Average();
    }
    class GenericClass<T> : IAbleToGetAverage
        where T : struct, IConvertible
    {
        private readonly T[] nums; // array of Number or subclass
        public GenericClass(T[] o)
        {
            nums = o;
        }
        private readonly IFormatProvider formatProvider = new NumberFormatInfo();
        public double Average()
        {
            var sum = 0.0;
            for(var i=0; i < nums.Length; i++)
                sum += nums[i].ToDouble(formatProvider);
            return sum / nums.Length;
        }
        public bool SameAvg(IAbleToGetAverage ob)
        {
            if(Math.Abs(Average() - ob.Average()) < double.Epsilon)
                return true;
            return false;
        }
    }
