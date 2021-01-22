    public bool Equals(CustomTag other)
    {
       return (other.Name.Trim().ToLower() == Name.Trim().ToLower());
	}
	public override bool Equals(object o)
	{
		if (o is CustomTag)
		{
			return Equals(o as CustomTag);
		}
		return false;
	}
