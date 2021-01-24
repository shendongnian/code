    SearchResults searchresults = new SearchResults(); //This is the Model used in the results.
    foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(searchresults))
    {
        var match = FilterableAttributes.FirstOrDefault(stringToCheck => stringToCheck.Contains(prop.Name));
        if (match != null)
        {
            var summary = new List(); 
            if(prop.Name == "prop1") // Place prop1 in a static constants variable
              {
            summary = results.GroupBy(c => c.yourProperty1).ToList(); //Here is where I'm stuck.
              }
            else if(prop.Name == "prop2")
              {
                  // go on
              }
        }
    }
