            var moneyString = "40 Thousand";
            var charArray = moneyString.ToCharArray();
            foreach (var character in charArray)
            {
                if (Char.IsLetter(character))
                {
                    // Likely not acceptable
                }
            }
