	public static int[] getRandomsWithTotalA(int desiredTotal, int desiredNumbers, int upperBound)
	{
		Random r = new Random();
		// Is this even a possible feat?
		if (desiredNumbers * upperBound < desiredTotal) throw new ArgumentException("This is not possible!", "desiredTotal");
		// Start by figuring out the closest number we can get to by repeating the initial number.
		int lowestRepeating = desiredTotal / desiredNumbers;
		// Determine the remainder
		int lowestRepeatingRemainder = desiredTotal % desiredNumbers;
		// Initialize and populate an array of numbers with the lowest repeater.
		int[] results = Enumerable.Repeat(lowestRepeating, desiredNumbers).ToArray();
		// We will perform (n*desiredTotal) shuffles.
		int shuffles = (desiredTotal * desiredNumbers);
		
		while (shuffles > 0)
		{
			int a = r.Next(desiredNumbers);
			int b= r.Next(desiredNumbers);
			if (a==b) continue; // do nothing if they're equal - try again.
			// Test bounds.
			if (results[a]+1>upperBound) continue;
			if (results[b]-1<0) continue;
			// Add one to the first item.
			results[a]++;
			// Do we still have a remainder left? If so, add one but don't subtract from
			// somewhere else.
			if (lowestRepeatingRemainder>0)
			{
				lowestRepeatingRemainder--;
				continue;
			}
			// Otherwise subtract from another place.
			results[b]--;
			// decrement shuffles
			shuffles--;
		}
		return results;
	}
	public static int[] getRandomsWithTotalB(int desiredTotal, int desiredNumbers, int upperBound)
	{
		Random r = new Random();
		// Is this even a possible feat?
		if (desiredNumbers * upperBound < desiredTotal) throw new ArgumentException("This is not possible!", "desiredTotal");
		// Initialize and populate an array of numbers with the lowest repeater.
		int[] results = new int[desiredNumbers];
		while (desiredTotal > 0)
		{
			int a = r.Next(desiredNumbers);
			// Test bounds.
			if (results[a] + 1 > upperBound) continue;
			// Add one to the first item.
			results[a]++;
			desiredTotal--;
		}
		return results;
	}
