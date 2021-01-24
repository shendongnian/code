    public RequestResponseDto MyMethod(bool isAdmin, Status status)
    {
        ...
        && 
        ((status == Status.Status1 && (r._REQUEST_STATUS_ID == RequestSubmitted || r._REQUEST_STATUS_ID == RequestPartiallyAuthorised))
        ||
        (status == Status.Status2 && (r._REQUEST_STATUS_ID == Something))
        ||
        (status == Status.Status3 && (r._REQUEST_STATUS_ID == SomethingElse || r._REQUEST_STATUS_ID == AnotherThing)))        
        ...
        && (isAdmin || ra.FACILITY_USER_ID == facilityUserId)
    
        ...
    }
