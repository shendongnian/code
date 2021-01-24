    public struct TwoPoints {
        private readonly Point one;
        private Point two;
        public void Foo() {
            one.Offset(5, 5); 
            Console.WriteLine(one.X); // 0
            two.Offset(5, 5);
            Console.WriteLine(two.X); // 5
        }
    }
