    class TestClass<T>
    {
       public string GetName<T>()
       {
          Type typeOfT = typeof(T);
          if(typeOfT == typeof(string))
          {
              //do string stuff
          }
       }
    }
