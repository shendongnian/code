	var original = new Response<Detail>()
	{
		Code = 42,
		Message = "OK",
		Result = new Detail()
		{
			Id = 1701,
			DetailOne = "Don't",
			DetailTwo = "Panic",
		},
		ResponseDateTime = DateTime.Now,
	};
	
	var json = JsonConvert.SerializeObject(original, Newtonsoft.Json.Formatting.Indented);
	
	var response = JsonConvert.DeserializeObject<Response<Newtonsoft.Json.Linq.JObject>>(json);
	
	if (response.Code == 42)
	{
		Detail detail = response.Result.ToObject<Detail>();
		
		/* Do something with `Detail`. */
	}
