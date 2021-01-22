    public void SetName(string newName)
    {
        if (ValidateName(newName) != ValidationResult.NameOk)
            throw new InvalidOperationException("name has not been correctly validated");
        name = newName;
    }
