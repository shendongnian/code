    public override bool TryConvert(ConvertBinder binder, out object result)
    {
    
        if (binder.Type == typeof(String))
        {
            result = node.Value;
    
            return true;
        }
    
        else
        {
            result = null;
            return false;
        }
    }
