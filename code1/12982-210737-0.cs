      public static class MyBaseListExtensions
      {
        public static IEnumerable<ClassA> GetAllAs(this List<MyBaseClass> list)
        {
          foreach (var obj in list)
          {
            if (obj is ClassA)
            {
              yield return (ClassA)obj;
            }
          }
        }
    
        public static IEnumerable<ClassB> GetAllbs(this List<MyBaseClass> list)
        {
          foreach (var obj in list)
          {
            if (obj is ClassB)
            {
              yield return (ClassB)obj;
            }
          }
        }
      }
