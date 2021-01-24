    private string GetCleanHex(string hex) {
        string legalCharacters = "0123456789ABCDEF";
        string result = hex.ToUpper();
        foreach (char c in result) {
            if (!legalCharacters.Contains(c))
                result = result.Replace(c.ToString(), string.Empty);
        }
    }
