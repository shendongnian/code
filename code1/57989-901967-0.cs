    public void DoSomething()
    {
        using (TransactionScope scope = new TransactionScope(TransactionScopeOptions.Required, TimeSpan.FromSeconds(60)))
        {
            MyDac();
    
            scope.Complete(); // If timeout occurrs, this line is never hit, scope is disposed, which causes rollback if Complete() was not called
        }
    }
    
    public class MyDac()
    {
    
        using (SqlConnection ...)
        {
            using (SqlCommand ...)
            {
                // Do something with ADO.NET here...it will autoenroll if a transaction scope is present
            }
        }
    }
