    public List<EMS_BUSINESSTYPE_MASTER> CustomerType(int Cust)
    {
        List<EMS_BUSINESSTYPE_MASTER> x = new List<EMS_BUSINESS_TYPE>();
        if (Cust == 1)
        {
            x = (from n in db.EMS_BUSINESSTYPE_MASTER
                    where n.BUSINESSTYPE_ID == 1
                    select n).ToList();
        }
        else
        {
            x = (from n in db.EMS_BUSINESSTYPE_MASTER
                    select n).ToList();
        }
        return x;
    }
