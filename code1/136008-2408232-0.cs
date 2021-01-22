    foreach (BusinessObject> value in _dictionnary.Values)
    {
        if(value.MustDoJob)
        {
            value.DoJob();
        }
    }
