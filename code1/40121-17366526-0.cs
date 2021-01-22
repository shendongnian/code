    ICustomerQuery custQuery = MsgRequest.AppendCustomerQueryRq();
    custQuery.IncludeRetElementList.Add("ListID");
    custQuery.IncludeRetElementList.Add("Name");
    custQuery.IncludeRetElementList.Add("FirstName");
    custQuery.IncludeRetElementList.Add("LastName");
    custQuery.IncludeRetElementList.Add("ShipAddress");
