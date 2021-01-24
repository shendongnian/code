    var result = inputList
        .Select(item => new A() { 
                                    myDict = item
                                               .GetType()
                                               .GetFields(BindingFlags.Instance | BindingFlags.Public))
                                               .ToDictionary(f => f.Name, f => f.GetValue(item)
                                })
        .ToList();
