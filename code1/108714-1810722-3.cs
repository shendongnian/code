    using static IronRuby.Ruby;
    class Print1To100WithoutLoopsDemo
    {
        static void Main() => 
          CreateEngine().Execute("(1..100).each {|i| System::Console.write_line i }");
    }
