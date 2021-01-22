    public static class Program()
    {
        public static void Main()
        {
            SomeObject o = new SomeObject();
            OtherMethod(o);
        }
        private static void OtherMethod(SomeObject x)
        {
            // lots of code here, but none that uses x
        }
    }
