    public static bool IsDocumentValid(WordprocessingDocument mydoc)
    {
        OpenXmlValidator validator = new OpenXmlValidator();
        var errors = validator.Validate(mydoc);
        foreach (ValidationErrorInfo error in errors)
            Debug.Write(error.Description);
        return (errors.Count() == 0);
    }
