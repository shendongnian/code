    public string FullModelInfo
    {
        get
        {
            return !string.IsNullOrEmpty(this.Notes) ? $"{ ModelName } - { Notes }"
            : $"{ ModelName }";
        }
    }
