    public static class Tuple
    {
        //Allows Tuple.New(1, "2") instead of new Tuple<int, string>(1, "2")
        public static Tuple<T1, T2> New<T1, T2>(T1 t1, T2 t2)
        {
            return new Tuple<T1, T2>(t1, t2);
        }
        //etc...
    }
