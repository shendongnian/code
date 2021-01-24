    emulatorAddr = Environment.GetEnvironmentVariable("PUBSUB_EMULATOR_HOST");
    if (emulatorAddr != null)
    {
        channel = new Channel(emulatorAddr, ChannelCredentials.Insecure);
        pub = PublisherServiceApiClient.Create(channel);
    }
    else
    {
        pub = PublisherServiceApiClient.Create();
    }
