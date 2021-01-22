    public object CreateByEnum(DataModelType modeltype)
    {
        string enumText = modelType.ToString(); // will return for example "Company"
        Type classType = Type.GetType(enumText); // the Type for Company class
        object t = Activator.CreateInstance(classType); // create an instance of Company class
        return t;
    }
