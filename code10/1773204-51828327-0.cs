    interface ILength {
        public int Length { get; private set; }
    }
    class StaticLength : ILength {
        public StaticLength(int length) {
            Length = length;
        }
    }
    void Main() {
        const int length = 10;
        ILength lengthDependency = new StaticLength(length);
        IDependency dep = new DependencyClass(lengthDependency);
        MainClass mainClass = new MainClass(lengthDependency, dep); 
    }
