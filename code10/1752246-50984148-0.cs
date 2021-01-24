	private Dictionary<Type, Func<int, DloExtention>> gets =
		new Dictionary<System.Type, Func<int, DloExtention>>()
		{
			{ typeof(Foo), WebserviceClient.GetFoo },
			{ typeof(Bar), WebserviceClient.GetBar },
			{ typeof(Etc), WebserviceClient.GetEtc },
		};
	
	public bool Get<T>(int i, out DloExtention result)
	{
	    result = null;
		var flag = false;
		if (gets.ContainsKey(typeof(T)))
		{
			result = gets[typeof(T)](i);
			flag = true;
		}
		return flag;
	}
