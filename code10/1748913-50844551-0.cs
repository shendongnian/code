    class CallDetails {
        public int Id { get; set; }
        //...
        IQueryable<CallDetailsChild> Children { get; set; }
        IQueryable<CallDetailsCaller> Callers { get; set; }
        //...
    }
    
    class CallDetailsChild {
        //...
    }
    
    class CallDetailsCaller {
        //...
    }
    
    //...
    
    private IQueryable<CallDetails> BaseQuery()
    {
        return _context.CallDetails
            .AsNoTracking()
            .Include(callDetail => callDetail.Callers)
            .Select(callDetail => new CallDetails
            {
                callDetail.Id,
                callDetail.EnteredByEmail,
                callDetail.CallStartTime,
                callDetail.CallDirectionIsIncoming,
                callDetail.CallThread_Id,
                Children = callDetail.Children.Select(child => new CallDetailsChild
                {
                    child.FirstName,
                    child.LastName,
                    child.DateOfBirth
                }),
                Callers = callDetail.Callers.Select(y => new CallDetailsCaller
                {
                    y.FirstName,
                    y.LastName,
                    y.PhoneNumber.Number
                }),
                callDetail.SensitiveCall,
                callDetail.SuccessStory
            });
    }
