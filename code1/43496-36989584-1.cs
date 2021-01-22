	
	class E16_DecimalDoubling
	{
		const int DIGITS_PER_LIMB = 18;                  // == floor(log10(2) * (63 - 1)), b/o carry
		const long LIMB_MODULUS = 1000000000000000000L;  // == 10^18
		public static int digit_sum_for_power_of_2 (int power_of_2)	
		{
			Trace.Assert(power_of_2 > 0);
			int total_digits = (int)Math.Ceiling(Math.Log10(2) * power_of_2);
			int total_limbs = (total_digits + DIGITS_PER_LIMB - 1) / DIGITS_PER_LIMB;
			var a = new long[total_limbs];
			int limbs = 1;
			a[0] = 2;
			for (int i = 1; i < power_of_2; ++i)
			{
				int carry = 0;
				for (int j = 0; j < limbs; ++j)
				{
					long new_limb = (a[j] << 1) | carry;
					carry = 0;
					if (new_limb >= LIMB_MODULUS)
					{
						new_limb -= LIMB_MODULUS;
						carry = 1;
					}
					a[j] = new_limb;
				}
				if (carry != 0)
				{
					a[limbs++] = carry;
				}
			}
			return E16_Common.digit_sum(a);
		}
	}
