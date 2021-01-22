    [WebMethod(MessageName="Add3")]
    **public double Add(double dValueOne, double dValueTwo, double dValueThree)**
    {
       return dValueOne + dValueTwo + dValueThree;
    }
    
    [WebMethod(MessageName="Add2")]
    **public int Add(double dValueOne, double dValueTwo)**
    {
       return dValueOne + dValueTwo;
    }
