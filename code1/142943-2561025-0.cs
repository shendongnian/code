    public class GenericClass<T, U> where T : IComparable<T>
    {
         // Class definition here
    }
    public class GenericCollection<T,U>  where T : IComparable<T>
    {
         private GenericClass<T, U>[] entries;
         public GenericClass<T, U> this[int index]
          {
             get{ return this.entries[index]; }
          }
    }
