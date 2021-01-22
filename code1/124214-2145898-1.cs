        static bool IsAlphaAndNumeric(string str) {
            bool hasDigits = false;
            bool  hasLetters=false;
            foreach (char c in str) {
                bool isDigit = char.IsDigit(c);
                bool isLetter = char.IsLetter(c);
                if (!(isDigit | isLetter))
                    return false;
                hasDigits |= isDigit;
                hasLetters |= isLetter;
            }
            return hasDigits && hasLetters;
        }
