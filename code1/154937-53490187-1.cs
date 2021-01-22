    class System.Object
    {
    	public string ToString(IFormatProvider provider)
    	{
    		return Number.FormatInt32(this, null, NumberFormatInfo.GetInstance(provider));
    	}
    }
