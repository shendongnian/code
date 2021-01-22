	
	class E16_DecimalSquaring
	{
		const int DIGITS_PER_LIMB = 9;  // language limit 18, half needed for holding the carry
		const int LIMB_MODULUS = 1000000000;
		public static int digit_sum_for_power_of_2 (int e)
		{
			Trace.Assert(e > 0);
			int total_digits = (int)Math.Ceiling(Math.Log10(2) * e);
			int total_limbs = (total_digits + DIGITS_PER_LIMB - 1) / DIGITS_PER_LIMB;
			var squared_power = new List<int>(total_limbs) { 2 };
			var result = new List<int>(total_limbs);
			result.Add((e & 1) == 0 ? 1 : 2);
			while ((e >>= 1) != 0)
			{
				squared_power = multiply(squared_power, squared_power);
				if ((e & 1) == 1)
					result = multiply(result, squared_power);
			}
			return E16_Common.digit_sum(result);
		}
		static List<int> multiply (List<int> lhs, List<int> rhs)
		{
			var result = new List<int>(lhs.Count + rhs.Count);
			resize_to_capacity(result);
			for (int i = 0; i < rhs.Count; ++i)
				addmul_1(result, i, lhs, rhs[i]);
			trim_leading_zero_limbs(result);
			return result;
		}
		static void addmul_1 (List<int> result, int offset, List<int> multiplicand, int multiplier)
		{
			// it is assumed that the caller has sized `result` appropriately before calling this primitive
			Trace.Assert(result.Count >= offset + multiplicand.Count + 1);
			long carry = 0;
			foreach (long limb in multiplicand)
			{
				long temp = result[offset] + limb * multiplier + carry;
				carry = temp / LIMB_MODULUS;
				result[offset++] = (int)(temp - carry * LIMB_MODULUS);
			}
			while (carry != 0)
			{
				long final_temp = result[offset] + carry;
				carry = final_temp / LIMB_MODULUS;
				result[offset++] = (int)(final_temp - carry * LIMB_MODULUS);
			}
		}
		static void resize_to_capacity (List<int> operand)
		{
			operand.AddRange(Enumerable.Repeat(0, operand.Capacity - operand.Count));
		}
		static void trim_leading_zero_limbs (List<int> operand)
		{
			int i = operand.Count;
			while (i > 1 && operand[i - 1] == 0)
				--i;
			operand.RemoveRange(i, operand.Count - i);
		}	
	}
