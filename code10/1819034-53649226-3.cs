      if (property != null) {
        foreach(string word in words) {
          FilteredList.AddRange(BaseList.FindAll(item => 
            // convert given string (word) to property value's type
            // and compare
            object.Equals(Convert.ChangeType(word, property.PropertyType), 
                          property.GetValue(item)))); 
      }
      else {
        // Property not found
      }
