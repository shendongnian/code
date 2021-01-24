    public string InputFileNameChanged
    {
        get { return _inputFileName; }
        set {
            _inputFileName = value;
            var trimmed = value.Trim();
            if (trimmed.Length >= 7) {
                // search file using trimmed
            }
        }
    }
