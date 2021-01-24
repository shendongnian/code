	public void prepareData()
	{ 
	    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
	
		var map = file.ToLookup(x => x.XValue);
		
		TempBuffer =
			Enumerable
				.Range(0, 240)
				.Select(x => unixTimestamp - x)
				.SelectMany(x =>
					map[x]
						.Concat(new DataPoint(UnixTODateTime(x).ToOADate(), 0)).Take(1))
				.ToArray();
	}
