        static bool IsAlphaNumeric(string str) {
            bool hasDigits = false;
            bool hasLetters = false;
            foreach (char c in str) {
                hasDigits |= char.IsDigit(c);
                hasLetters |= char.IsLetter(c);
                if (hasDigits && hasLetters)
                    return true;
            }
            return false;
        }
