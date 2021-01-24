    public bool TryDeserialize<T1, T2>(string json, out object target)
    {            
            
        try
        {
            target = JsonConvert.DeserializeObject<T1>(json);
            return true;
        }
        catch (Exception)
        {
        }
        try
        {
            target = JsonConvert.DeserializeObject<T2>(json);
            return true;
        }
        catch (Exception)
        {
            target = null;
            return false;
        }
    }
