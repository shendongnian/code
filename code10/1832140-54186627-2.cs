    using(MyWcfClient proxy = new MyWcfClient())
    {
        try
        {
            proxy.Calculate();
        }
        catch(Exception)
        {
        }
    }
