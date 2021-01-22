    public class MultiReturnValueHelper<T1, T2, T3> : Tuple<T1, T2, T3>
    {
        internal MultiReturnValueHelper(T1 item1, T2 item2, T3 item3)
            : base(item1, item2, item3)
        {
        }
        public static implicit operator T1(MultiReturnValueHelper<T1, T2, T3> source)
        {
            return source.Item1;
        }
        public static implicit operator T2(MultiReturnValueHelper<T1, T2, T3> source)
        {
            return source.Item2;
        }
        public static implicit operator T3(MultiReturnValueHelper<T1, T2, T3> source)
        {
            return source.Item3;
        }
    }
