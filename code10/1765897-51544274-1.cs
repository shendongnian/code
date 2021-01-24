    public void AddItemsToCollection(IEnumerable names, string control)
    {           
      switch (control)
      {  
        case "TypeDeclarate":
          AddTypeDeclarateItems(names);
          break;
        case "QualityDeclarate":
          AddQualityDeclarateItems(names);
          break;
      }
    }
