	string Add(string s1, string s2)
	{
			bool carry = false;
		    string result = string.Empty;
		  
			if (s1.Length < s2.Length)
				s1 = s1.PadLeft(s2.Length, '0');
			if(s2.Length < s1.Length)
				s2 = s2.PadLeft(s1.Length, '0');
			for(int i = s1.Length-1; i >= 0; i--)
			{
				var augend = Convert.ToInt64(s1.Substring(i,1));
				var addend = Convert.ToInt64(s2.Substring(i,1));
				var sum = augend + addend;
				sum += (carry ? 1 : 0);
				carry = false;
				if(sum > 9)
				{
					carry = true;
					sum -= 10;
				}
				result = sum.ToString() + result;
			}
			if(carry)
			{
				result = "1" + result;
			}
		return result;
	}
