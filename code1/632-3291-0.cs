    public static class Base
    {
        public static virtual int GetNumber() { return 5; }
    }
    public static class Child1 : Base
    {
        public static override int GetNumber() { return 1; }
    }
    public static class Child2 : Base
    {
        public static override int GetNumber() { return 2; }
    }
