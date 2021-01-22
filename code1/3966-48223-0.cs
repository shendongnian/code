    static class AtoBCopier
    {
        public static B Copy(A item)
        {
            return new B() { Prop1 = item.Prop1, Prop2 = item.Prop2 };
        }
    }
