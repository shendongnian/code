    		public static string RemoveMultiSpace(string input)
		{
			var value = input;
			if (!string.IsNullOrEmpty(input))
			{
				var isSpace = false;
				var index = 0;
				var length = input.Length;
				var tempArray = new char[length];
				for (int i = 0; i < length; i++)
				{
					var symbol = input[i];
					if (symbol == ' ')
					{
						if (!isSpace)
						{
							tempArray[index++] = symbol;
						}
						isSpace = true;
					}
					else
					{
						tempArray[index++] = symbol;
						isSpace = false;
					}
				}
				var result = new char[index];
				Array.Copy(tempArray, 0, result, 0, index);
				value = new string(result);
			}
			return value;
		}
