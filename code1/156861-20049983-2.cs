    public interface ICovariantTuple<out T1>
    {
        T1 Item1 { get; }
    }
    public class CovariantTuple<T1> : Tuple<T1>, ICovariantTuple<T1>
    {
        public CovariantTuple(T1 item1) : base(item1) { }
    }
    public interface ICovariantTuple<out T1, out T2>
    {
        T1 Item1 { get; }
        T2 Item2 { get; }
    }
    public class CovariantTuple<T1, T2> : Tuple<T1, T2>, ICovariantTuple<T1, T2>
    {
        public CovariantTuple(T1 item1, T2 item2) : base(item1, item2) { }
    }
    etc.... for 3, 4, 5, 6, 7, 8 items
