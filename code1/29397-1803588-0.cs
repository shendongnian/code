    using System.Reflection;
    
    Assembly MyDALL = Assembly.Load("DALL"); //DALL name of your assembly
    Type MyLoadClass = MyDALL.GetType("DALL.LoadClass"); // name of your class
     object  obj = Activator.CreateInstance(MyLoadClass);
  
