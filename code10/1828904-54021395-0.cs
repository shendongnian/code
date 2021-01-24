    public IEnumerable<EMS_BUSINESSTYPE_MASTER> CustomerType(int Cust)
    {
        var x = db.EMS_BUSINESSTYPE_MASTER; // no need for the `select`
        if (Cust == 1)
        {
            x = x.Where(z => z.BUSINESSTYPE_ID == 1);
        }
        return x;
    }
