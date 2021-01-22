    class Test{
      static void Main(){
         Transformer square = Square;
         Console.WriteLine(square(3));
      } 
      static int Square (int x) {return x*x;}
    }
