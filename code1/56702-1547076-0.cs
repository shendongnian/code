     class Program
     {
      static void Main(string[] args)
      {
       // this is the approach described
       string RedToString = MyEnum.Red.ToString();
    
       // We're pretending that red was the zeroth element when we did (int)MyEnum.Red;
       int RedToInt = 0;
    
       MyEnum RedFromString = (MyEnum)Enum.Parse(typeof(MyEnum), RedToString);
       MyEnum RedFromInt = (MyEnum)RedToInt;
    
       // this is in theory how RedToInt was persisted
       int BlackFromInt = (int)MyEnum.Black;
    
       Console.WriteLine("RedToString: " + RedToString); // Red
       Console.WriteLine("RedToInt: " + RedToInt); // 0
       Console.WriteLine("RedFromString: " + RedFromString); // Red
       Console.WriteLine("RedFromInt: " + RedFromInt); // Black
       Console.WriteLine("BlackFromInt: " + BlackFromInt); // 0
       Console.Read();
      }
    
      enum MyEnum
      {
       Black,
       Red,
       Blue,
      }
     }
