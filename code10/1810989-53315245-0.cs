    var result= from req in DB.Table_Request
                join service in DB.Table_Service
                on req.Service_id equals  service.id
               select new ServiceRequests
               {
                 Name=service.Name,
                 ServiceID=req.Service_Id,
                 // Followed model Properties 
                }.ToList();
                 
