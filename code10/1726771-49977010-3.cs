    public bool CanUpdateUser(string userName, out string errorMessage)
    {
        bool result = SafetyExecuteFunctionWithOut<string, string, bool>(_innerSession.CanUpdateUser, userName, out errorMessage);
        return result;
    }
