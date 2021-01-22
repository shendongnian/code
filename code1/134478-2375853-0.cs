    if (!IsReadOnly)
    {
        T newobj = null;
        try
        {
            newobj = DataPortal.Update<T>(this);    
        }
        catch (DataPortalException)
        {
            // TODO: Implement DataPortal.Update<T>() recovery mechanism
        }
        if (newobj != null)
        {
            List<string> keys = new List<string>(BasicProperties.Keys);
            foreach (string key in keys)
            {
                BasicProperties[key] = newobj.BasicProperties[key];
            }
        }
    }
