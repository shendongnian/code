    struct Tuple<T,U> {
       public Tuple(T first, U second) { 
           First = first;
           Second = second;
       }
       public T First { get; private set; }
       public U Second { get; private set; }
    }
    static class Tuple {
       // The following method is declared to take advantage of
       // compiler type inference features and let us not specify
       // the type parameters manually.
       public static Tuple<T,U> Create(T first, U second) {
            return new Tuple<T,U>(first, second);
       }
    }
    return Tuple.Create(firstList, secondList);
