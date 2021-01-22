    const string ContractExceptionName =
        "System.Diagnostics.Contracts.__ContractsRuntime.ContractException";
    public static void ExpectContractFailure(Action action)
    {
        try
        {
            action();
            Assert.Fail("Expected contract failure");
        }
        catch (Exception e)
        {
            if (e.GetType().FullName != ContractExceptionName)
            {
                throw;
            }
            // Correct exception was thrown. Fine.
        }
    }
