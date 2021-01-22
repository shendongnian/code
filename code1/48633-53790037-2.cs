    public void MyMethod(string a, int b)
    {
        //validate each
        Objects.RequireNotNull(a);
        Objects.RequireNotNull(b);
        //or validate in single line as array 
        Objects.RequireNotNullArray(a, b);
    }
