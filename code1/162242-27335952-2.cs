    if (IsProperty(() => DynamicObject.MyProperty))
      ; // do stuff
    delegate string GetValueDelegate();
    private bool IsProperty(GetValueDelegate getValueMethod)
    {
        try
        {
            //we're not interesting in the return value.
            //What we need to know is whether an exception occurred or not
            var v = getValueMethod();
            return v != null;
        }
        catch (RuntimeBinderException)
        {
            return false;
        }
        catch
        {
            return true;
        }
    }
