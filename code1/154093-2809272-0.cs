        private static Dictionary<int, string> errorCodes = 
        new Dictionary<int, string>()
        {
            {100, "Request completed successfuly"},
            {200, "Missing name in request."}
        };
        private string RetrieveMessage(int value)
        {
            string message;
            if (!errorCodes.TryGetValue(value, out message))
                message = "Unexpected failure, please email for support";
            return message;
        }
