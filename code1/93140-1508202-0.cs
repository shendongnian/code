        private string newLines(int multiplier)
        {
            StringBuilder newlines = new StringBuilder();
            for (int i = 0; i < multiplier; i++)
                newlines.Append(Environment.NewLine);
            return newlines.ToString();
        }
