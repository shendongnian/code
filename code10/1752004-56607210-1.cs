          var cred = SdkContext.AzureCredentialsFactory.FromServicePrincipal(client, key, tenant, AzureEnvironment.AzureGlobalCloud);
          var botClient = new AzureBotServiceClient(cred);
          botClient.SubscriptionId = subscription;
          
          var config = new BotChannel()
          {
            Location = "global",
            Properties = new FacebookChannel(new FacebookChannelProperties(facebookAppId, facebookAppSecret, true))
          };
          await botClient.Channels.CreateAsync(resourceGroupName, connectorName, ChannelName.FacebookChannel, config);
