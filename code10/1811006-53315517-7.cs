    public IEnumerable<ServiceRequestsVM> ServiceRequestGetAll()
    {
        var result = DB.ServiceRequests.Join(DB.Services,
                                             x => x.Service_Id, // Source table foreign key
                                             y => y.Id, // Joined table primary key
                                             (x, y) => new ServiceRequestsVM { Id = x.Id, Service_Id = x.Service_Id, Name = y.Name, Description = x.Description, Requestor = x.Requestor, Status = x.Status })
                                            .OrderBy(z => z.Service_Id).ToList();
    
        return result;
    }
