    using System;
    using System.Collections.Generic;
    using System.Text;
    static class Program {
        static void Main() {
            MyVector x = new MyVector(1, 2, 3), y = new MyVector(1, 2, 3), z = new MyVector(4,5,6);
            Console.WriteLine(x == y); // true
            Console.WriteLine(x == z); // false
            Console.WriteLine(object.Equals(x, y)); // true
            Console.WriteLine(object.Equals(x, z)); // false
            var comparer = EqualityComparer<MyVector>.Default;
            Console.WriteLine(comparer.GetHashCode(x)); // should match y
            Console.WriteLine(comparer.GetHashCode(y)); // should match x
            Console.WriteLine(comparer.GetHashCode(z)); // *probably* different
            Console.WriteLine(comparer.Equals(x,y)); // true
            Console.WriteLine(comparer.Equals(x,z)); // false
            MyVector sum = x + z;
            Console.WriteLine(sum);
        }
    }
    class MyVector : IEquatable<MyVector> {
        private readonly int[] data;
        public int this[int index] {
            get { return data[index]; }
        }
        public MyVector(params int[] data) {
            if (data == null) throw new ArgumentNullException("data");
            this.data = (int[])data.Clone();
        }
        private int? hash;
        public override int GetHashCode() {
            if (hash == null) {
                int result = 13;
                for (int i = 0; i < data.Length; i++) {
                    result = (result * 7) + data[i];
                }
                hash = result;
            }
            return hash.GetValueOrDefault();
        }
        public override bool Equals(object obj) {
     	     return this == (obj as MyVector);
        }
        public bool Equals(MyVector obj) {
            return this == obj;
        }
        public override string ToString() {
            StringBuilder sb = new StringBuilder("[");
            if (data.Length > 0) sb.Append(data[0]);
            for (int i = 1; i < data.Length; i++) {
                sb.Append(',').Append(data[i]);
            }
            sb.Append(']');
            return sb.ToString();
        }
        public static bool operator ==(MyVector x, MyVector y) {
            if(ReferenceEquals(x,y)) return true;
            if(ReferenceEquals(x,null) || ReferenceEquals(y,null)) return false;
            if (x.hash.HasValue && y.hash.HasValue && // exploit known different hash
                x.hash.GetValueOrDefault() != y.hash.GetValueOrDefault()) return false;
            int[] xdata = x.data, ydata = y.data;
            if(xdata.Length != ydata.Length) return false;
            for(int i = 0 ; i < xdata.Length ; i++) {
                if(xdata[i] != ydata[i]) return false;
            }
            return true;        
        }
        public static bool operator != (MyVector x, MyVector y) {
            return !(x==y);
        }
        public static MyVector operator +(MyVector x, MyVector y) {
            if(x==null || y == null) throw new ArgumentNullException();
            int[] xdata = x.data, ydata = y.data;
            if(xdata.Length != ydata.Length) throw new InvalidOperationException("Length mismatch");
            int[] result = new int[xdata.Length];
            for(int i = 0 ; i < xdata.Length ; i++) {
                result[i] = xdata[i] + ydata[i];
            }
            return new MyVector(result);
        }
    }
