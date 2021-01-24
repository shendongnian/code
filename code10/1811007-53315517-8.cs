    public IEnumerable<ServiceRequestsVM> ServiceRequestGetAll()
    {
        var result = (from srv in DB.Services
                     join srq in DB.ServiceRequests
                     on srv.Id equals srq.Service_Id
                     select new ServiceRequestsVM
                     {
                         Id = srq.Id,
                         Service_Id = srq.Service_Id,
                         Name = srv.Name,
                         Description = srq.Description,
                         Requestor = srq.Requestor,
                         Status = srq.Status
                     }).OrderBy(z => z.Service_Id).ToList();
        return result;
    }
