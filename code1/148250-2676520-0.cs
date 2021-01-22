    using System.Reflection;    
    var myNewData = from t in someOtherData
            select new
            { 
                fieldName = t.Whatever,
                fieldName2 = t.SomeOtherWhatever
            };
    foreach (PropertyInfo pinfo in myNewData[0].GetType().GetProperties()) 
    { 
        string name = pinfo.Name; 
    }
    // or if you need all strings in a list just use:
    List<string> propertyNames = myNewData[0]
                 .GetType().GetProperties().Select(x => x.Name).ToList();
