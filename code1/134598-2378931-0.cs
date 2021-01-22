    container.AddFacility("WcfSessionFacility", new WcfSessionFacility());
    container.Kernel.AddComponentWithExtendedProperties(
        "AccountService",
        typeof(IAccountService),
        typeof(AccountServiceClient),
        new Dictionary<string, object>()
            {
                { WcfSessionFacility.ManageWcfSessionsKey, true }
            });
