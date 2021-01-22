    using System;
    
    class C
    {
        static int n;
    
        static void P() { System.Console.WriteLine(++n); }
    
        static void X2(Action a) { a(); a(); }
    
        static void X5(Action a) { X2(a); X2(a); a(); }
    
        static void Main() { X2(() => X5(() => X2(() => X5(P)))); }
    }
