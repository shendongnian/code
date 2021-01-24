    public IQueryable<ServiceRequestsVM> ServiceRequestGetAll()
    {
        var result = DB.ServiceRequests.Join(DB.Services,
                                             x => x.Id, // First table ID
                                             y => y.Service_Id, // Second table ID
                                             (x, y) => new ServiceRequestsVM { Id = y.Id, Service_Id = y.Service_Id, Name = x.Name, Description = y.Description, Requestor = y.Requestor, Status = y.Status })
                                            .OrderBy(z => z.Service_Id);
    
        return result;
    }
