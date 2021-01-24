    public class MyInt : IComparable {
        public int value;
        public MyInt(int newv) => value = newv;
    
        public int CompareTo(object obj) {
            if (obj is MyInt m2) {
                return value.CompareTo(m2.value);
            }
            else if (obj is int i2) {
                return value.CompareTo(i2);
            }
            else {
                throw new Exception($"can't compare MyInt to {obj.GetType()}");
            }
        }
    }
    var e = Enumerable.Repeat(1, 10_000_000).Select(_ => new MyInt(r.Next()));
