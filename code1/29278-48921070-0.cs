    public static class TextValidator
    {
        public enum ValidationType
        {
            Amount,
            Integer
        }
        /// <summary>
        /// Validate a textbox on text change.
        /// </summary>
        /// <param name="tbx"></param>
        /// <param name="validationType"></param>
        public static void Validate(this TextBox tbx, ValidationType validationType)
        {
            PerformValidation(tbx, validationType);
            tbx.Select(tbx.Text.Length, 0);
        }
        private static void PerformValidation(this TextBox tbx, ValidationType validationType)
        {
            char[] enteredString = tbx.Text.ToCharArray();
            switch (validationType)
            {
                case ValidationType.Amount:
                    tbx.Text = AmountValidation(enteredString);
                    break;
                case ValidationType.Integer:
                    tbx.Text = IntegerValidation(enteredString);
                    break;
                default:
                    break;
            }
            tbx.SelectionStart = tbx.Text.Length;
        }
        private static string AmountValidation(char[] enteredString)
        {
            string actualString = string.Empty;
            int count = 0;
            foreach (char c in enteredString.AsEnumerable())
            {
                if (count >= 1 && c == '.')
                { actualString.Replace(c, ' '); actualString.Trim(); }
                else
                {
                    if (Char.IsDigit(c))
                    {
                        actualString = actualString + c;
                    }
                    if (c == '.')
                    {
                        actualString = actualString + c; count++;
                    }
                    else
                    {
                        actualString.Replace(c, ' ');
                        actualString.Trim();
                    }
                }
            }
            return actualString;
        }
        private static string IntegerValidation(char[] enteredString)
        {
            string actualString = string.Empty;
            foreach (char c in enteredString.AsEnumerable())
            {
                if (Char.IsDigit(c))
                {
                    actualString = actualString + c;
                }
                else
                {
                    actualString.Replace(c, ' ');
                    actualString.Trim();
                }
            }
            return actualString;
        }
    }
