    public struct SizeType
    {
        private int InternalValue { get; set; }
        public static readonly int Small = 0;
        public static readonly int Medium = 1;
        public static readonly int Large = 2;
        public static readonly int ExtraLarge = 3;
        public override bool Equals(object obj)
        {
            SizeType otherObj = (SizeType)obj;
            return otherObj.InternalValue.Equals(this.InternalValue);
        }
        public static bool operator >(SizeType left, SizeType right)
        {
            return (left.InternalValue > right.InternalValue);
        }
		public static bool operator <(SizeType left, SizeType right)
		{
			return (left.InternalValue < right.InternalValue);
		}
        public static implicit operator SizeType(int otherType)
        {
            return new SizeType
            {
                InternalValue = otherType
            };
        }
    }
    public class test11
    {
        void myTest()
        {
            SizeType smallSize = SizeType.Small;
            SizeType largeType = SizeType.Large;
            if (smallSize > largeType)
            {
                Console.WriteLine("small is greater than large");
            }
        }
    }
