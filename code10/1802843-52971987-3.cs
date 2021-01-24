    public class IntHolder
    {
        public int X
        {
            get;
            set;
        }
    }
    public class ImmutableStruct //changed to class
    {
        public int ImmutableInt
        {
            get;
            private set;
        }
        public ImmutableIntHolder IntHolder
        {
            get;
            private set;
        }
        public ImmutableStruct(int immutableInt, IntHolder myIntHolder) //: this()
        {
            ImmutableInt = immutableInt;
            IntHolder = new ImmutableIntHolder(myIntHolder); // convert here.
        }
        public class ImmutableIntHolder
        {
            public ImmutableIntHolder(IntHolder intHolder)
            {
                //map all properties
                X = intHolder.X;
            }
            public int X
            {
                get;
                private set;
            }
        }
    }
