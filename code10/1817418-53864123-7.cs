    Awake()
    {
        UnityInitializer.AttachToGameObject(gameObject);
        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;
        AmazonGameLiftConfig gameLiftConfig = new AmazonGameLiftConfig
        {
                RegionEndpoint = RegionEndpoint.USWest1
        };
        m_Client = new AmazonGameLiftClient(
                    "awsAccessKeyId",
                    "awsSecretAccessKey",
                    gameLiftConfig);
    }
