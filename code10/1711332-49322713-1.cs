    public SignalRMasterClient(string url) {
                Url = url;
                Connection = new HubConnection(url, useDefaultUrl: false);
                Hub = Connection.CreateHubProxy("ServiceStatusHub");
                Connection.Start().ContinueWith(task => { if (task.IsFaulted) {
                        Console.WriteLine("There was an error opening the connection:{0}",
                                          task.Exception.GetBaseException());
                    } else {
                        Console.WriteLine("Connected");
                    }
                });
    
                Hub.On<string>("acknowledgeMessage", (message) =>
                {
                    Console.WriteLine("Message received: " + message);
    
                    /// TODO: Check status of the LDAP
                    /// and update status to Web API.
                }).Wait();
            }
