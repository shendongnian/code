    public string this[ColumnName]
    {
      if (Column == "TextProperty")
      {
        if(!ValidateTextProperty())
          return "TextProperty is invalid";
      }
    }
    
    void Save(object param)
    {
      if (CanSave)
      {
         if (string.IsNullOrEmpty(this["TextProperty"])
         {
            //Add Save code here
         }
      }
    }
