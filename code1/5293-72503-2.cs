      class Level1
      {
      }
    
      class Level2A : Level1
      {
      }
    
      class Level2B : Level1
      {
      }
    
      class Level3A2A : Level2A
      {
      }
      class Program
      {
        static void Main(string[] args)
        {
          object[] objects = new object[] {"testing", new Level1(), new Level2A(), new Level2B(), new Level3A2A(), new object() };
    
    
          ReturnMatch(typeof(Level1), objects);
          Console.ReadLine();
        }
    
    
        static void ReturnMatch(Type arbitraryType, object[] objects)
        {
          foreach (object obj in objects)
          {
            Type objType = obj.GetType();
    
            Console.Write(arbitraryType.ToString() + " is ");
    
            if (!arbitraryType.IsAssignableFrom(objType))
              Console.Write("not ");
    
            Console.WriteLine("assignable from " + objType.ToString());
    
          }
        }
      }
