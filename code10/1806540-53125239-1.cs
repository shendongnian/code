    public class FruitFactory<T> where T : Fruit
    {
        public T Create()
        {
            // instantiate your fruit object here
            // ....
        }
    }
    var factory = new FruitFactory<Banana>();
    Banana banana = factory.Create();
