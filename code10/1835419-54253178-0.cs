    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class MyAttribute : Attribute
    {
        private readonly MyEnum myEnum;
        public MyAttribute(int number)
        {
            this.myEnum = GetEnumFromNumber(number);
            // OR: this.myEnum = (MyEnum)number;
        }
    }
