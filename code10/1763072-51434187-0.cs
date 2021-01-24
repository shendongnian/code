	public enum MyKeys
	{
		KeyCode.Space,
		KeyCode.A,
		KeyCode.W,
		KeyCode.S,
		KeyCode.D
	}
    KeyCode CheckMyKey()
	{
		foreach(var i in Enum.GetValues(typeof(MyKeys)))
		{
			if (Input.GetKeyDown(i))
				return i;
		}
	}
