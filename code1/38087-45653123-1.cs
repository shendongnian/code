    private void Test_Environment_Variables()
    {
        string BaseDir = ConfigurationManager.AppSettings["EnvironmentVariableExample"];
        string ExpandedPath = Environment.ExpandEnvironmentVariables(BaseDir).Replace("\"", ""); //The function addes a " at the end of the variable
        Console.WriteLine($"From within the C# Console Application {ExpandedPath}");
    }
