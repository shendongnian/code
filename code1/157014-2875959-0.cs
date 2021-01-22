      public abstract class CarDecorator
      {
        protected Car DecoratedCar { get; private set; }
    
        protected CarDecorator(Car decoratedCar)
        {
          DecoratedCar = decoratedCar;
        }
      }
    
      public class SuperCar : CarDecorator
      {
        public SuperCar(Car car)
          : base(car)
        {
        }
        public int HorsePower
        {
          get { return horsePower; }
          set { horsepower = value; }
        }
        public override void Display()
        {
          DecoratedCar.Display()
          Console.WriteLine("Plus I'm a super car.");
        }
      }
