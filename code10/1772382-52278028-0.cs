       services.AddTransient<Transverse.TokenService.ITokenService>(provider =>
            {
                var client = new Transverse.TokenService.TokenServiceClient();
                client.Endpoint.Address = new System.ServiceModel.EndpointAddress(Configuration["Services:TokenService"]);
                return client;
            });
