    var result = inputList
        .Select(item => new A() { 
                                    myDict = item
                                               .GetType() // get item's type declaration
                                               .GetFields(BindingFlags.Instance | BindingFlags.Public)) // get all public non static fileds of item's class
                                               .ToDictionary(f => f.Name, f => f.GetValue(item) // get dictionary with field name as the key and field value as the value
                                })
        .ToList();
