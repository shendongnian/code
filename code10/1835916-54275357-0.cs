    namespace ConsoleApp1
    {
      public class Program
      {
        public static void Main(string[] args)
        {
          List<B> list = new List<B>();
          list = list.Where(b => list.Where(innerB => innerB.MOTHER == b.ID).Count() > 0).ToList();
        }
      }
      public class B { public int ID; public int MOTHER; }
    }
