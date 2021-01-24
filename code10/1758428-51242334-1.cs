       [MyCustomAttribute(...)]
       public class Product {...}
    
       var list = new List<Product>();
       ...
    
       MyCustomAttribute[] attributes = list
         .Where(item => item != null)
         .SelectMany(item => item.GetType().GetCustomAttributes<MyCustomAttribute>())
         .ToArray();
