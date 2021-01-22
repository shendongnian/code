    List<MyCustomClass> listCustClass = new List<MyCustomClass>();
    try
    {
        listCustClass = GetList();
    }
    catch (SqlException)
    {
    }
    return listCustClass;
    
