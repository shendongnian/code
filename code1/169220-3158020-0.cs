    string.Format("Some message {0} {1}", "Parameter one", EncloseInParenthsisIfNotEmpty(""))
    public string EncloseInParenthsisIfNotEmpty(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";
        return string.Format("({0})", input);
    }
