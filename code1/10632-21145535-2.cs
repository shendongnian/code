     namespace OOP
     {
         class Program
         {
             static void Main(string[] args)
             {
                 Child somechild = new Child();
                 somechild.doHomeWork();
                 somechild.myFather.work();
                 somechild.myMother.cook();
                 Console.ReadLine();
             }
         }
         public class Father 
         {
             public Father() { }
             public void work()
             {
                 Console.WriteLine("working...");
             }
             public void nap()
             {
                 Console.WriteLine("napping...");
             }
         }
   
         public class Mother 
         {
             public Mother() { }
             public void cook()
             {
                 Console.WriteLine("cooking...");
             }
             public void clean()
             {
                 Console.WriteLine("cleaning...");
             }
         }
   
         public class Child 
         {
             public Father myFather { get; set; }
             public Mother myMother { get; set; }
     
             public Child()
             {
                 myFather = new Father();
                 myMother = new Mother();
             }
             public void goToSchool()
             {
                 Console.WriteLine("go to school...");
             }
             public void doHomeWork()
             {
                 Console.WriteLine("doing homework...");
             }
         }
     }
