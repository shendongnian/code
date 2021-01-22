    public abstract class Fruit<T>
        where T : Fruit<T>, new()
    {
        public static T CreateInstance()
        {
            T newFruit = new T();
            newFruit.Initialize();  // Calls Apple.Initialize
            return newFruit;
        }
    
        protected abstract void Initialize();
    }
    
    public class Apple : Fruit<Apple>
    {
        protected override void Initialize() { ... }
    }
