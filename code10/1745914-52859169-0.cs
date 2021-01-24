     using (var availabilityService = new NetworkProductAvailabilityCheckerServiceClient())
                {
                    availabilityService.ClientCredentials.UserName.UserName = "your username here";
                    availabilityService.ClientCredentials.UserName.Password = "your password here";
                    var availabilityRequest = new NetworkProductAvailabilityRequest
                    {
                        
                        UserConsent = UserConsent.Yes,
                        AccessCircuit = new[] { "EAD" },
                        RequestDetails = new PostcodeAvailabilityRequest
                        {
                            Postcode = input
                        }
                    };
                 } 
