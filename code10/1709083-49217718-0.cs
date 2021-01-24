		private string Transpose(string input)
		{
			StringBuilder result = new StringBuilder();
			foreach (var character in input)
			{
				if (character == '0')
				{
					result.Append(character);
				}
				else if (character >= '1' && character <= '9')
				{
					int offset = character - '1';
					char replacement = (char)('A' + offset);
					result.Append(replacement);
				}
				else if (character >= 'A' && character <= 'Z') // I'm assuming upper case only; feel free to duplicate for lower case
				{
					int offset = character - 'A' + 1;
					result.Append(offset);
				}
				else
				{
					throw new ApplicationException($"Unexpected character: {character}");
				}
			}
			return result.ToString();
		}
