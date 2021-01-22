    class Program
    {
        static void Main(string[] args)
        {
            if (2.Chain() < 3 < 4)
            {
                Console.WriteLine("Yay!");
            }
        }
    }
    public class Chainable<T> where T : IComparable<T>
    {
        public Chainable(T value)
        {
            Value = value;
            Failed = false;
        }
        
        public Chainable()
        {
            Failed = true;
        }
        public readonly T Value;
        public readonly bool Failed;
        
        public static Chainable<T> Fail { get { return new Chainable<T>(); } }
        public static Chainable<T> operator <(Chainable<T> me, T other)
        {
            if (me.Failed)
                return Fail;
            return me.Value.CompareTo(other) == -1
                       ? new Chainable<T>(other)
                       : Fail;
        }
        public static Chainable<T> operator >(Chainable<T> me, T other)
        {
            if (me.Failed)
                return Fail;
            return me.Value.CompareTo(other) == 1
                       ? new Chainable<T>(other)
                       : Fail;
        }
        public static Chainable<T> operator ==(Chainable<T> me, T other)
        {
            if (me.Failed)
                return Fail;
            return me.Value.CompareTo(other) == 0
                       ? new Chainable<T>(other)
                       : Fail;
        }
        public static Chainable<T> operator !=(Chainable<T> me, T other)
        {
            if (me.Failed)
                return Fail;
            return me.Value.CompareTo(other) != 0
                       ? new Chainable<T>(other)
                       : Fail;
        }
        public static bool operator true(Chainable<T> me)
        {
            return !me.Failed;
        }
        public static bool operator false(Chainable<T> me)
        {
            return me.Failed;
        }
        public override bool Equals(object obj)
        {
            return Value.Equals(obj);
        }
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
    public static class ChainExt
    {
        public static Chainable<T> Chain<T>(this T value) where T : IComparable<T>
        {
            return new Chainable<T>(value);
        }
    }
