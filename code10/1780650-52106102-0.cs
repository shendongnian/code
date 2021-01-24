    class MyClass
    {
       public static List<string> myList{ get; set;}
       public static void MyMethod()
       {
          var myFile = File.ReadLines("File.txt");
          myList = new List<string>(myFile);
       }
    }
