    public bool TryDeserialize(string json, out object target, params Type[] types)
    {            
        foreach (Type type in types)
        {
            try
            {
                target = JsonConvert.DeserializeObject(json, type);
                return true;
            }
            catch (Exception)
            {                    
            }
        }
        target = null;
        return false;
    }
