    public ActorNotificationDbHandler()
    {
        DbAccount dbAccount = Core.Server.SRefCoreServer.dbHandler.DBAccounts[0];
                
        _dbFactory = new OrmLiteConnectionFactory($"Uid={dbAccount.Username};Password={dbAccount.Password};Server={dbAccount.Address};Port={dbAccount.Port};Database={dbAccount.Database}", MySqlDialect.Provider);
        _db = _dbFactory.Open();
        SetTableMeta();
        if (_db.CreateTableIfNotExists<ActorNotification>())
        {
            _db.Insert(new ActorNotification { CreatedTime = DateTime.Now, ToActor = 123, Status = ActorNotification.ActorNotificationStatuses.Created });
            _db.Insert(new ActorNotificationMessage { ActorNotificationId = 1, MessageState = ActorNotificationMessage.MessageStates.Created });
        }
        var result = _db.SingleById<ActorNotification>(1);
        result.PrintDump(); //= {Id: 1, Name:Seed Data}
    }
