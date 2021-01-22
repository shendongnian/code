    class P
    {
        static int n;
    
        static void P1() { System.Console.WriteLine(++n); }
    
        static void P2() { P1(); P1(); }
    
        static void P4() { P2(); P2(); }
    
        static void P8() { P4(); P4(); }
    
        static void P16() { P8(); P8(); }
    
        static void P32() { P16(); P16(); }
    
        static void P64() { P32(); P32(); }
    
        static void Main() { P64(); P32(); P4(); }
    }
