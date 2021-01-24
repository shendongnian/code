    interface IInterface
    {
        string CommonProperty1 { get; set; }
        string CommonProperty2 { get; set; }
    }
    class Individual : IInterface
    {
        // ...
    }
    class Group : IInterface
    {
        // ...
    }
    public IInterface CreateObject(SqlDataReader indata)
    {
        if((indata["Associate"].ToString()) == "0")
        {
            var individual = new Individual();
            // ...  
            return individual;
        }
        else
        {
            var group = new Group();
            // ...
            return group;
        }
    }
