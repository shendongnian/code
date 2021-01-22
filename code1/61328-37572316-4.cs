    public sealed class myKey : Tuple<TypeA, TypeB, TypeC>
    {
        public myKey(TypeA dataA, TypeB dataB, TypeC dataC) : base (dataA, dataB, dataC) { }
        
        public TypeA DataA => Item1; 
        
        public TypeB DataB => Item2;
        public TypeC DataC => Item3;
    }
