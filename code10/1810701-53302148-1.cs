    private static bool IsValidJson<T>(string strInput,out T obj)
    {
        obj = default(T);
        try
        {
            obj = JsonConvert.DeserializeObject<T>(strInput);
            return true;
        }
        catch (JsonReaderException jex)
        {
            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
