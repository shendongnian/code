        public class PseudoEnum
    {
        public const int FirstValue = 1;
        private static PseudoEnum FirstValueObject = new PseudoEnum(1);
        public const int SecondValue = 2;
        private static PseudoEnum SecondValueObject = new PseudoEnum(2);
        private int intValue;
        // This prevents instantation; note that we cannot mark the class static
        private PseudoEnum() {}
        private PseudoEnum(int _intValue)
        {
            intValue = _intValue;
        }
        public static implicit operator int(PseudoEnum i)
        {
            return i.intValue;
        }
        public static implicit operator PseudoEnum(int i)
        {
            switch (i)
            {
                case FirstValue :
                    return FirstValueObject;
                case SecondValue :
                    return SecondValueObject;
                default:
                    throw new InvalidCastException();
            }
        }
        public static void DoSomething(PseudoEnum pe)
        {
            switch (pe)
            {
                case PseudoEnum.FirstValue:
                    break;
                case PseudoEnum.SecondValue:
                    break;
            }
        }
    }
