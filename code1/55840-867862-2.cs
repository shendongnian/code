    using (var trans = new  System.Transactions.TransactionScope(
                               TransactionScopeOption.Required,
                               new TransactionOptions {
                                   IsolationLevel = IsolationLevel.ReadCommitted
                               },
                               EnterpriseServicesInteropOption.Automatic)) {
        // Perform operations using your DC, including submitting changes
        if (allOK) {
            trans.Complete();
        }
    }
