    IDictionary<string, string[]> errorsByField = new Dictionary<string, string[]>();
    
    foreach (var key in ModelState.Keys) {
       if (ModelState[key].Errors.Any()) {
           var errors = ModelState[key].Errors.Select(e => e.ErrorMessage).ToArray();
           errorsByField.Add(key, errors);
       }
    }
