    public List<IMyClass> Fill(
      string[] ItemsPassedByParam, 
      Func<string,IMyClass> createFunc)
      List MyList = new List<IMyClass>();
      foreach (item in ItemsPassedByParam) {
        MyList.Add(createFunc(item));        
      }
    }
