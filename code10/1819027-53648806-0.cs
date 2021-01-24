     foreach(string word in words)
     {
         var propertyInfo = object.GetType().GetProperty(word);
         var propertyValue = propertyInfo.GetValue(x);
         FilteredList.AddRange(BaseList.FindAll(x => propertyValue == word));    
     }
