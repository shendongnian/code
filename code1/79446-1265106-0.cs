    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new FaultException<GeneralFault>(
                new GeneralFault {Message = "Attempt to divide by zero"});
        }
    
        return a / b; // Note - operation can focus on its job
    }
