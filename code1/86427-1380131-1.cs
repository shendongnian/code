    public abstract class Fruit
    {
        protected Fruit() {}
        public abstract string Define();
    }
    
    public class Apple : Fruit
    {
        public Apple() {}
        public override string Define()
        {
             return "Apple";
        }
    }
    
    public class Orange : Fruit
    {
        public Orange() {}
        public override string Define()
        {
             return "Orange";
        }
    }
    
    public static class FruitFactory<T> 
    {
         public static T CreateFruit<T>() where T : Fruit, new()
         {
             return new T();
         }
    }
