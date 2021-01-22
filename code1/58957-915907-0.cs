    class Foo
    {
       public enum BarChoice { a,b,c };
       public int x(Bar bar, BarChoice bc)
       {
         switch(bc) 
         {
           case a:
             return bar.A * 2;
           case b:
             return bar.B * 2;
           case c:
             return bar.C * 2;
         }
         return int.MinValue;
       }
    }
