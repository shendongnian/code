       interface IBark { void Bark(); }
       public class Dog:Pet,IBark {
         public Dog(string name):base(name)
         {}
         public void Bark()
         {
            Console.WriteLine(String.Format("{0}: bark", Name));
         }
       }
       //do same changes with cat
 
