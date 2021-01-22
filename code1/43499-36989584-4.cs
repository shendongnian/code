	
	internal class E16_Common
	{
		internal static int digit_sum (int limb)
		{
			int sum = 0;
			for ( ; limb > 0; limb /= 10)
				sum += limb % 10;
			return sum;
		}
		internal static int digit_sum (long limb)
		{
			const int M1E9 = 1000000000;
			return digit_sum((int)(limb / M1E9)) + digit_sum((int)(limb % M1E9));
		}
		internal static int digit_sum (IEnumerable<int> limbs)
		{
			return limbs.Aggregate(0, (sum, limb) => sum + digit_sum(limb));
		}
		internal static int digit_sum (IEnumerable<long> limbs)
		{
			return limbs.Select((limb) => digit_sum(limb)).Sum();
		}
	}
