    public class Factory
    {
        public T CreateFruit<T>() where T : Fruit
        {
            // instantiate your fruit object here
            // ....
        }
    }
    var factory = new Factory();
    Apple apple = factory.CreateFruit<Apple>();
