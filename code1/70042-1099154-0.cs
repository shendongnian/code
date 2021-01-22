    struct Tuple<T,U> {
       public Tuple(T first, U second) { 
           First = first;
           Second = second;
       }
       public T First { get; set; }
       public U Second { get; set; }
    }
    static class Tuple {
       public static Tuple<T,U> Create(T first, U second) {
            return new Tuple<T,U>(first, second);
       }
    }
    return Tuple.Create(firstList, secondList);
