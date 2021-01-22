    public abstract class Fruit<T>
        where T : Fruit<T>, new()
    {
        public static T CreateInstance()
        {
            T newFruit = new T();
            newFruit.Initialize();  // Calls Apple.Initialize
            return newFruit;
        }
        protected abstract Initialize();
    }
    public class Apple : Fruit<Apple>
    {
        protected Initialize() { ... }
    }
