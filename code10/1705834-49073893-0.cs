    var result = JsonConvert.DeserializeObject<List<Test>>(json string, new JsonSerializerSettings
        {
            Error = HandleDeserializationError
        });
    
    public void HandleDeserializationError(object sender, ErrorEventArgs errorArgs)
    {
        var currentError = errorArgs.ErrorContext.Error.Message;
        errorArgs.ErrorContext.Handled = true;
    }
