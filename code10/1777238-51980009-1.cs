    public static async void PostUploadtoCloud(List<Dictionary<string, byte[]>> _commonFileCollection)
    {
	 Dictionary<string, Byte[]> _dickeyValuePairs = new Dictionary<string, byte[]>();
    try
    {
	 foreach (var item in _commonFileCollection)
	  {
		foreach (var kvp in item)
		{
			//you can also use TryAdd
			if(!_dickeyValuePairs.Contains(kvp.Key))
			{
				_dickeyValuePairs.Add(kvp.Key, kvp.Value);
			}
			else
			{
				//send message that it could not be done?
			}
		}
		
	   }
     }
     catch(Exception e)
     {
      //log exception
     } 
    }
