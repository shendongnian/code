    public class MarvellousArray<T>
       where T : new()
    {
       private readonly T[] _array;
    
       public MarvellousArray(int size)
       {
          _array = new T[size];
          for (var i = 0; i < size; i++)
             _array[i] = new T();
          
       }
       ...
