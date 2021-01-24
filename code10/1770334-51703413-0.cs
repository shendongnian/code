    Week w = new Week();
    var props = typeof(Week).GetProperties();
    for(int i = 0; i < 7; i++)
    {
        // set properties, e.g. using reflection:
        props[i].SetValue(w, myValue);
    }
