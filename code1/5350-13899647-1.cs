    object obj = new object();
    Guid? guid = null; 
    bool b = obj.IsNull(); // false
    b = guid.IsNull(); // true
    2.IsNull(); // error
