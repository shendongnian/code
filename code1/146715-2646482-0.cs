    bool isList(object data)
    {
        System.Collections.IList list = data as System.Collections.IList;
        return list != null;
    }
    
    ...
    if (isList(obj)) {
        //do stuff that take special care of object which is a List
        //It will be true for generic type lists too!
    }
