    var list = XMLFile.Select(someObjs => {
        dynamic nestedObj = Activator.CreateInstance(
           Type.GetType(someObjs.Element("nestedObj").Element("type")));
        nestedObj.NestedName = (string)someObjs.Element("nestedObj").Element("name");
        return new someObj {
            Name = (string)someObjs.Element("name"),
            NestedObj = nestedObj
        };
    }).ToList();
