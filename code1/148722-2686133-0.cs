    //Hash any object:
    FieldwiseHasher.Hash(myCustomStructOrClass);
   
    //implementation:
    public static class FieldwiseHasher {
        public static int Hash<T>(T val) { return FieldwiseHasher<T>.Instance(val); }
    }
    public static class FieldwiseHasher<T> {
        public static readonly Func<T, int> Instance = CreateLambda().Compile();
        //...
    }
