      if (String.CompareOrdinal(
            Path.GetDirectoryName(typeof(String).Assembly.Location), 
            Path.GetDirectoryName(typeof(MyType).Assembly.Location)
          ) == 0)
      {
        //Framework Type
      }
      else
      {
        //3rd Party DLL
      }
