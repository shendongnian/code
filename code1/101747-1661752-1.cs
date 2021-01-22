    abstract class BaseClass {
        public BaseClass(int x) { X = x; }
        public int X { get; private set; }
        public override bool  Equals(object other) {
            if (!(other is BaseClass)) {
                return false; 
            }
            BaseClass otherBaseClass = (BaseClass)other;
            return (otherBaseClass.X == this.X);
        }
        public BaseClass ToBaseClass() {
            return (BaseClass)this;
        }
    }
    class ClassA : BaseClass {
        public ClassA(int x, int y) : base (x) {
            Y = y;
        }
        public int Y { get; private set; }
    }
    class ClassB : BaseClass {
        public ClassB(int x, int z) : base (x) {
            Z = z;
        }
        public int Z { get; private set; }
    }
    class Program {
        static void Main(string[] args) {
            var a = new ClassA(1, 2);
            var b = new ClassB(1, 3);
            Assert.AreEqual(a.ToBaseClass(), b.ToBaseClass());
        }
    }
