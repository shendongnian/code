    // creating a derived class for readability.
    public class DepotIDToListOfCustomerIDs : Dictionary<int,List<int>> {}
    public class CustomerIDToListOfDepotIDs : Dictionary<int,List<int>> {}
    public class DepotIDToDepotObject : Dictionary<int,Depot>{}
    public class CustomerIDToCustomerObject : Dictionary<int, Customer>{}
    //...
    // class scope for a class that manages all these objects...
    DepotIDToListOfCustomerIDs _d2cl = new DepotIDToListOfCustomerIDs();
    CustomerIDToListOfDepotIDs _c2dl = new CustomerIDToListOfDepotIDs();
    DepotIDToDepotObject _d2do = new DepotIDToDepotObject();
    CustomerIDToCustomerObject _c2co = new CustomerIDToCustomerObject();
    //...
    // Populate all the lists with the cross referenced info.
    //...
    // in a method that needs to build a list of depots for a given customer
    // param: Customer c
    if (_c2dl.ContainsKey(c.ID))
    {
        List<int> dids=_c2dl[c.ID];
        List<Depot> ds=new List<Depot>();
        foreach(int did in dids)
        {
            if (_d2do.ContainsKey(did))
                ds.Add(_d2do[did]);
        }
    }
    // building the list of customers for a Depot would be similar to the above code.
