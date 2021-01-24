    public Person(IDALPerson d)
    {
            dal = d;           
    }
        
    private IDALPerson dal;
    public void SendOrder()
    {            
        (Other logic...)
        dal.SendOrder("Bananas");
    }
