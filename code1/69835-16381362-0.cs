     public static void Main()
     {
         StringWrapper testVariable = new StringWrapper("before passing");
         Console.WriteLine(testVariable);
         TestI(testVariable);
         Console.WriteLine(testVariable);
     }
     public static void TestI(StringWrapper testParameter)
     {
         testParameter = new StringWrapper("after passing");
         // this will change the object that testParameter is pointing/referring
         // to but it doesn't change testVariable unless you use a reference
         // parameter as indicated in other answers
     }
