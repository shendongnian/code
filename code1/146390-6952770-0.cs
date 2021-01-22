    public sealed class ExpectContractFailureAttribute : ExpectedExceptionBaseAttribute
    {
        const string ContractExceptionName = "System.Diagnostics.Contracts.__ContractsRuntime+ContractException";
        protected override void Verify(Exception exception)
        {
            if (exception.GetType().FullName != ContractExceptionName)
            {
                base.RethrowIfAssertException(exception);
                throw new Exception(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Test method {0}.{1} threw exception {2}, but contract exception was expected. Exception message: {3}",
                        base.TestContext.FullyQualifiedTestClassName,
                        base.TestContext.TestName,
                        exception.GetType().FullName,
                        exception.Message
                    )
                );
            }
        }
    }
