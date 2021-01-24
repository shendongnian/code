    public class IntHolder
    {
        public int X
        {
            get;
            set;
        }
        public ImmutableIntHolder ToImmutable()//convert itself to ImmutableIntHolder 
        {
            return new ImmutableIntHolder(X);
        }
    }
    public class ImmutableIntHolder
    {
        public ImmutableIntHolder(int x)
        {
            X = x;
        }
        public int X
        {
            get;
            private set;
        }
        public IntHolder ToIntHolder() //convert it back to mutable IntHolder 
        {
            return new IntHolder()
            {
                X = this.X
            };
        }
    }
    public struct ImmutableStruct
    {
        public int ImmutableInt
        {
            get;
            private set;
        }
        public ImmutableIntHolder IntHolder //use ImmutableIntHolder instead
        {
            get;
            private set;
        }
        public ImmutableStruct(int immutableInt, IntHolder myIntHolder) : this()
        {
            ImmutableInt = immutableInt;
            IntHolder = myIntHolder.ToImmutable(); // convert to immutable
        }
    }
