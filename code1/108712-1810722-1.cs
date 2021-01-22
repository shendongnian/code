    using IronRuby;
    class Print1To100WithoutLoopsDemo
    {
        static void Main()
        {
            Ruby.CreateEngine().Execute("(1..100).each {|i| puts i}");
        }
    }
