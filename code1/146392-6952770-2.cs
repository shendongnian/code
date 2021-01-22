        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Cannot catch ContractException")]
        public static void ContractFailure(Action operation)
        {
            try
            {
                operation();
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "System.Diagnostics.Contracts.__ContractsRuntime+ContractException")
                    return;
                throw;
            }
            Assert.Fail("Operation did not result in a code contract failure");
        }
