    var propName = data?.Properties?.PropertyName;
    var isPropNameFound = !string.IsNullOrEmpty(propName);
    var prop = isPropNameFound ? _assets.GetPropertyByName(propName) : null;
    if (isPropNameFound && (prop == null))
    {
        // Add new property if name was given, and it 
        // was not found to already have been added?
    }
