    public class Adapter<T> : IAnimal
    {
       private T x;
       Adapter(T x)
       {
         this.x = x;
       }
       public void eat()
       {
         x.GetType().GetMethod("eat").Invoke(this);
       }
    }
