        private bool IsAllCharEnglish(string Input)
        {
            foreach (var item in Input.ToCharArray())
            {
                if (!char.IsLower(item) && !char.IsUpper(item) && !char.IsDigit(item) && !char.IsWhiteSpace(item))
                {
                    return false;
                }
            }
            return true;
        }
