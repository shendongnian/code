       // If it's a static method, this is fine:
        public Func<T, TResult> DaFunc = RelevantClass.DoSomeStuff<T, TResult>;
        // If not, something like this is needed:
        public UselessClass(SomeClassWhereTheFunctionIs from)
        {
           DaFunc = from.DoSomeStuff<T, TResult>;
        }
    }
