    [DivideByZeroExceptionFilter]
    public void Delete(int id)
    {
        // causes the DivideByZeroExceptionFilter attribute to be triggered:
        throw new DivideByZeroException(); 
    }
