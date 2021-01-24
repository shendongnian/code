	var requestJson = Newtonsoft.Json.JsonConvert.SerializeObject(
		new
		{
			positionsQuery = new
			{
				positionDate = positionDate.Date.ToString("yyyyMMdd"),
				measures = new []{"margin"}
			}
		});
