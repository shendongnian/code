	if (newHits.Any())
	{
		int newHitIndex = 0;
		var allHitsList = allHists.ToList();
		for(var index =0; index < allHitsList.Count; ++index)
		{
			var h = allHitsList[index]
			if (h.Type == type)
			{
				var newHit = newHits[newHitIndex];
				allHitsList[index] = newHit;
				newHitIndex++;
			}
		}
	}
