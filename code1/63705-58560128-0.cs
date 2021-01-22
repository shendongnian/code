    private static int GetHresult(System.Exception exception)
    {
        int retValue = -666;
    
        try
        {
            System.Reflection.PropertyInfo piHR = typeof(System.Exception).GetProperty("HResult", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            if (piHR != null)
            {
                object o = piHR.GetValue(exception, null);
                retValue = System.Convert.ToInt32(o);
            }
        }
        catch (Exception ex)
        {
        }
    
        return retValue;
    }
