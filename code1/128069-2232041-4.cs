    private BusinessEntity getNote(ICrmService service, guid noteid)
    {
      // Create the column set object that indicates the fields to be retrieved.
      ColumnSet cols = new ColumnSet();
    
      // Set the columns to retrieve, you can use allColumns but its good practice to specify:
      cols.Attributes = new string [] {"name"};
    
      // Create the target object for the request.
      TargetRetrieveAnnotation target = new TargetRetrieveAnnotation();
    
      // Set the properties of the target object.
      // EntityId is the GUID of the record being retrieved.
      target.EntityId = noteid;
    
      // Create the request object.
      RetrieveRequest retrieve = new RetrieveRequest();
    
      // Set the properties of the request object.
      retrieve.Target = target;
      retrieve.ColumnSet = cols;
    
      // Execute the request.
      RetrieveResponse retrieved = (RetrieveResponse)service.Execute(retrieve);
      return RetrieveResponse;
    }
