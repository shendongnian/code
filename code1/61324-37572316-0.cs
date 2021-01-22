    public sealed class myKey : Tuple<TypeA, TypeB, TypeC>
    {
        public myKey(TypeA dataA, TypeB dataB, TypeC dataC) : base (dataA, dataB, dataC) { }
        
        public TypeA DataA { get { return Item1; } }
        
        public TypeB DataB { get { return Item2; } }
        public TypeC DataC { get { return Item3; } }
    }
