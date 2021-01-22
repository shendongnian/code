    public class PatternMatcher<Output>
    {
        List<Tuple<Predicate<Object>, Func<Object, Output>>> cases = new List<Tuple<Predicate<object>,Func<object,Output>>>();
    
        public PatternMatcher() { }        
    
        public PatternMatcher<Output> Case(Predicate<Object> condition, Func<Object, Output> function)
        {
            cases.Add(new Tuple<Predicate<Object>, Func<Object, Output>>(condition, function));
            return this;
        }
    
        public PatternMatcher<Output> Case<T>(Predicate<T> condition, Func<T, Output> function)
        {
            return Case(
                o => o is T && condition((T)o), 
                o => function((T)o));
        }
    
        public PatternMatcher<Output> Case<T>(Func<T, Output> function)
        {
            return Case(
                o => o is T, 
                o => function((T)o));
        }
    
        public PatternMatcher<Output> Case<T>(Predicate<T> condition, Output o)
        {
            return Case(condition, x => o);
        }
    
        public PatternMatcher<Output> Case<T>(Output o)
        {
            return Case<T>(x => o);
        }
    
        public PatternMatcher<Output> Default(Func<Object, Output> function)
        {
            return Case(o => true, function);
        }
    
        public PatternMatcher<Output> Default(Output o)
        {
            return Default(x => o);
        }
    
        public Output Match(Object o)
        {
            foreach (var tuple in cases)
                if (tuple.Item1(o))
                    return tuple.Item2(o);
            throw new Exception("Failed to match");
        }
    }
