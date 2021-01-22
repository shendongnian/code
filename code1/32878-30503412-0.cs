    public bool RunBusinessRule(MyCustomType customType)
    {
      try
        {
           if (customType.CustomBoolProperty == true)
           {
        		DoSomething(); 
                return true;
           }
           
           return false;
        }
        catch(Exception)
        {
        	throw;
        }
    }
