    IList<ListItem> GetItems(string control)
    {
      switch (control)
      {  
        case "TypeDeclarate":
          return TypeDeclarate.Items;
        case "QualityDeclarate":
          return QualityDeclarate.Items;       
      }
      throw new SomeException(...);
    }
