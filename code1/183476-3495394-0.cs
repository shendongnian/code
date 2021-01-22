    namespace ConsoleApplication2
    {
      class Program
      {
        static void Main(string[] args)
        {
          Pets pet1 = new Dog();
          Pets pet2 = new Cat();
          pet1.Say();
          pet2.Say();
          Console.ReadKey();
        }
      }
    
      class Pets
      {
       public virtual void Say() {
          Console.WriteLine("Pet makes generic noise");
     }
      }
    
      class Dog : Pets
      {
        public override void Say() { Console.WriteLine("Dog barks."); }
      }
    
      class Cat : Pets 
      {
        public override void Say() { Console.WriteLine("Cat meows."); }
      }
    }
