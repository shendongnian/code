        string AddSpacesToSentence(string value, bool spaceLowerChar = true, bool spaceDigitChar = true, bool spaceSymbolChar = false)
        {
            var result = "";
            for (int i = 0; i < value.Length; i++)
            {
                char currentChar = value[i];
                char nextChar = value[i < value.Length - 1 ? i + 1 : value.Length - 1];
                if (spaceLowerChar && char.IsLower(currentChar) && !char.IsLower(nextChar))
                {
                    result += value[i] + " ";
                }
                else if (spaceDigitChar && char.IsDigit(currentChar) && !char.IsDigit(nextChar))
                {
                    result += value[i] + " ";
                }
                else if(spaceSymbolChar && char.IsSymbol(currentChar) && !char.IsSymbol(nextChar))
                {
                    result += value[i];
                }
                else
                {
                    result += value[i];
                }
            }
            return result;
        }
