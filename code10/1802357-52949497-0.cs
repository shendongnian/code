    public class ListItemValue<T>
    {
       public ListItemValue(string name, T value)
       {
          Name = name;
          Value = value;
       }
    
       public string Name { get; }
    
       public T Value { get; }
    }
 
