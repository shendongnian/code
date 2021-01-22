    using (var trans = new TransactionScope(
                               TransactionScopeOption.Required,
                               new TransactionOptions {
                                   IsolationLevel = IsolationLevel.ReadCommitted
                               },
                               EnterpriseServicesInteropOption.Automatic)) {
        // Perform operations using your DC
        if (alOK) {
            trans.Complete();
        }
    }
