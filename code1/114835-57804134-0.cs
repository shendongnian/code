    public static string WordsToCapitalLetter(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("value");
			}
			int inputValueCharLength = value.Length;
			var valueAsCharArray = value.ToCharArray();
			int min = 0;
			int max = inputValueCharLength - 1;
			
			while (max > min)
			{
				char left = value[min];
				char previousLeft = (min == 0) ? left : value[min - 1];
				char right = value[max];
				char nextRight = (max == inputValueCharLength - 1) ? right : value[max - 1];
				if (char.IsLetter(left) && !char.IsUpper(left) && char.IsWhiteSpace(previousLeft))
				{
					valueAsCharArray[min] = char.ToUpper(left);
				}
				if (char.IsLetter(right) && !char.IsUpper(right) && char.IsWhiteSpace(nextRight))
				{
					valueAsCharArray[max] = char.ToUpper(right);
				}
				min++;
				max--;
			}
			return new string(valueAsCharArray);
		}
