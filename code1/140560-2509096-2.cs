    Console.WriteLine("Good: " + new Good().Equals(new Good { d = -.0 }));
    Console.WriteLine("Bad: " + new Bad().Equals(new Bad { d = -.0 }));
    public struct Good {
        public double d;
        public int f;
    }
    public struct Bad {
        public double d;
    }
