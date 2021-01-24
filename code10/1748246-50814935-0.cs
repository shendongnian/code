    public class Foo : IDisposable
    {
        private ICar car;
        public Foo()
        {
            car = CurrentUnityContainer.Container.Resolve<Car>();
        }
        public MyMethod()
        {
            car.DoSomething();
        }
        public void Dispose()
        {
            car.Dispose();
        }
    }
