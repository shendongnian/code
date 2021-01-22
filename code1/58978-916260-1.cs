    DateTime StartDate { get; set; }
    DateTime EndDate { get; set;}
    bool IsValid()
    {
       return StartDate > EndDate      
    }
