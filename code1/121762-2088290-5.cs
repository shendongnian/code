    public partial class MyClass2 {
        public partial bool HasRealSolution(double a, double b, double c) {
            var delta = b*b - 4*a*c;
            return delta >= 0;
        }
    }
    public partial class MyClass2 {
        public partial void HasRealSolution(double a, double b, double c) {
            return false;
        }
    }
