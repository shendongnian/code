    public class FooBarFactory : IFooBarFactory
    {
        public IFooModel Create(IFoo someClass)
        {
        // some complex model building code here
            IBarData barData = new ConcreteBarData();
            IFooModel model = new ConcreteFooModel(someClass.data1, someClass.data1, barData);
        }
    }
