    var result = inputList
        .Select(item => new R() { 
                                    myDict = item
                                               .GetType()
                                               .GetFields(BindingFlags.Instance | BindingFlags.Public))
                                               .ToDictionary(f => f.Name, f => f.GetValue(r)
                                })
        .ToList();
