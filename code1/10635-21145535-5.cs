     namespace OOP
     {
         class Program
         {
             static void Main(string[] args)
             {
                 Child somechild = new Child();
                 somechild.DoHomeWork();
                 somechild.CheckingAround();
                 Console.ReadLine();
             }
         }
         public class Father 
         {
             public Father() { }
             public void Work()
             {
                 Console.WriteLine("working...");
             }
             public void Moonlight()
             {
                 Console.WriteLine("moonlighting...");
             }
         }
   
         public class Mother 
         {
             public Mother() { }
             public void Cook()
             {
                 Console.WriteLine("cooking...");
             }
             public void Clean()
             {
                 Console.WriteLine("cleaning...");
             }
         }
   
         public class Child 
         {
             public Father MyFather { get; set; }
             public Mother MyMother { get; set; }
     
             public Child()
             {
                 MyFather = new Father();
                 MyMother = new Mother();
             }
             public void GoToSchool()
             {
                 Console.WriteLine("go to school...");
             }
             public void DoHomeWork()
             {
                 Console.WriteLine("doing homework...");
             }
             public void CheckingAround()
             {
                 MyFather.Work();
                 MyMother.Cook();
             }
         }
     }
