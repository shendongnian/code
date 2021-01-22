	private NotifyValue<int> _val;
	public const string ValueProperty = "Value";
	public int Value
	{
		get { return _val.Value; }
		set { _val.Value = value; }
	}
