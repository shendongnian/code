    interface IQueueInfoProvider
    {
       DataStructure FetchData();
    }
    
    class Version1QueueInfoProvider : IQueInfoProvider
    {
       DataStructure FetchData()
       {
          //Fetch using Version1 Assemblies.
       }
    }
    
    class Version2QueueInfoProvider : IQueInfoProvider
    {
       DataStructure FetchData()
       {
           //Fetch using Version2 Assemblies.
       }
    }
