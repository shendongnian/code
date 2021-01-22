    // Using something like
    public class Wrapped<T> {
        public Wrapped(T initial) {
            this.Value = initial;
        }
        public T Value { get; set; }
    }
    // You can do:
    bool flag=false;
    var int1 = new Wrapped<int>(0);
    var int2 = new Wrapped<int>(1);
    Wrapped<int> iRef = flag ? int2 : int1;
    iRef.Value = iRef.Value + 1;
