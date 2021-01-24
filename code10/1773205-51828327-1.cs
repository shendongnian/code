    interface ILength {
        int Length { get; }
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
