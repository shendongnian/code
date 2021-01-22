    public int MyProperty
    {
        get
        {
            return (int)_propertyBag["MyProperty"];
        }
        set
        {
            if(_propertyBag.Keys.Contains("MyProperty"))
            {
              _propertyBag["MyProperty"] = value;
            }
            else
            {
              _propertyBag.Add("MyProperty", value);
            }
        }
    }
