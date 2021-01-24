    var redisHost = AppSettings.GetString("RedisHost");
    if (redisHost != null)
    {
        container.Register<IRedisClientsManager>(
            new RedisManagerPool(redisHost));
    
        container.Register<IServerEvents>(c => 
            new RedisServerEvents(c.Resolve<IRedisClientsManager>()));
        
        container.Resolve<IServerEvents>().Start();
    }
