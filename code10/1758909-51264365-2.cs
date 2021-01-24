    public class Order : Attribute
    {
       public Order(int value)
       {
           Value = value
       }
    
       public int Value{ get; }
    }
    
    
    [Order(1)]
    public MyClass<T> : IConsumer<T>
    {
    }
    
    foreach (var type in types.OrderBy(r => 
                r.GetCustomAttributes(true).OfType<Order>().FirstOrDefault().Value))
    {
    }
