    using System.Diagnostics;
    namespace Test
    {
      internal static class Program
      {
        private static void Main()
        {
          var dog = new Dog();
          SaveAnimal(dog);
        }
        private static void SaveAnimal(Animal animal)
        {
          var isAnimal = animal.GetType().UnderlyingSystemType == typeof(Animal);
          Debug.Assert(isAnimal, "You can not save dogs!");
        }
        private static void SaveAnimal(ICanNotSave animal)
        {
          Debug.Fail("Can not save");
        }
      }
      internal class Animal
      {
        public int Legs
        {
          get; set;
        }
      }
      internal interface ICanNotSave
      {
      }
      internal sealed class Dog : Animal, ICanNotSave
      {
        public int TailLength
        {
          get; set;
        }
      }
    }
