    IDictionary<string, string[]> errorsByField = new Dictionary<string, string[]>();
    
    foreach (var key in ModelState.Keys) {
       if (ModelState[key].Errors.Count() > 0) {
           var errors = ModelState[key].Errors.Select(e => e.ErrorMessage).ToArray();
           errorsByField.Add(key, errors);
       }
    }
