     foreach(string word in words)
     {
         var propertyInfo = object.GetType().GetProperty(word);
         FilteredList.AddRange(BaseList.FindAll(x => propertyInfo.GetValue(x) == word));    
     }
