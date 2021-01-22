    public string getMessageFromErrorCode(int code)
    {
        switch (code)
        {
            case 1: return "OK";
            case 2: return "Syntax Error";
            case 3: return "Other error";
        }
    }
