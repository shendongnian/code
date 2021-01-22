    try
    {
        // query service for object by key
    }
    catch (System.ServiceModel.FaultException e)
    {
        if (e.Message == "Business object not found.")
        {
            // create new object
        }
        else
        {
            // log the exception appropriately
        }
    }
