    public abstract class TupleBase<T1>
    {
        public T1 Argument1 { get; private set; }
        public TupleBase(T1 argument1)
        {
           this.Argument1 = argument1;
        }
    }
    public abstract class TupleBase<T1, T2>
    {
        public T1 Argument1 { get; private set; }
        public T2 Argument2 { get; private set; }
        public TupleBase(T1 argument1, T2 argument2)
        {
           this.Argument1 = argument1;
           this.Argument2 = argument2;
        }
    }
    public abstract class TupleBase<T1, T2, T3>
    {
        public T1 Argument1 { get; private set; }
        public T2 Argument2 { get; private set; }
        public T3 Argument3 { get; private set; }
        public TupleBase(T1 argument1, T2 argument2, T3 argument3)
        {
           this.Argument1 = argument1;
           this.Argument2 = argument2;
           this.Argument3 = argument3;
        }
    }
    //  Etc..
