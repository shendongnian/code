    public class Child<T>
    {
       public string Type
       {
           get { return typeof(T).ToString(); }
       }
    }
