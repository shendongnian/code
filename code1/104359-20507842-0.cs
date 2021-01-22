    _host = new ServiceHost(_server.CreateManagementService());
                    var endpoint = _host.AddServiceEndpoint(typeof(IManagementService),
                        new WSHttpBinding(SecurityMode.Message),
                        _serviceEndpoint);
                    for (int i = 0; i < _host.Description.Behaviors.Count; i++)
                    {
                        if (_host.Description.Behaviors[i] is AspNetCompatibilityRequirementsAttribute)
                        {
                            _host.Description.Behaviors.RemoveAt(i);
                            break;
                        }
                    }
                    _host.Description.Behaviors.Add(new AspNetCompatibilityRequirementsAttribute { RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed });
                    _host.Open();
