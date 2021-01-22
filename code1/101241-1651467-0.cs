    public class DerivedClass : BaseClass
    {
        public DerivedClass(int i)
            : base(ChooseInputType(i))
        {
        }
        private static InputType ChooseInputType(int i)
        {
            // Logic
            return InputType.Number;
        }
    }
