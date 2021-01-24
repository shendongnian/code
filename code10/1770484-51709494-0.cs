    public static bool IsOverlap(IEnumerable<IndividualFee> fees)
	{
		var limit = int.MinValue;
		foreach (var fee in fees.OrderBy(f => f.MinValue))
		{
			if (fee.MinValue <= limit)
			{
				return true;
			}
			
			limit = fee.MinValue;
			
			if (fee.MaxValue <= limit)
			{
				return true;
			}
			
			limit = fee.MaxValue;
			
		}
		
		return false;
	}
