     var device = new DeviceData
                {
                    
                    CrmWeb = new Dictionary<string, IxData>
                    {
                        {
                            "stable", new IxData
                            {
                                IxRepo = "100028"
                            }
                        },
                        {
                            "release", new IxData
                            {
                                IxRepo = "101543"
                            }
                        }
                    },
                    Rarautomation = new Dictionary<string, IxData>
                    {
                        {
                            "stable", new IxData
                            {
                                
                                IxRepo = "100024"
                            }
                        }
                    },
                    Models = new Dictionary<string, IxData>
                    {
                        {
                            "stable", new IxData
                            {
                                IxRepo = "100341"
                            }
                        },
                        {
                            "PhaseOutDefaultModel", new IxData
                            {
                                IxRepo = "102088"
                            }
                        }
                    },
                };
    
                var json = JsonConvert.SerializeObject(device, new JsonSerializerSettings()
                {
    
                    Formatting =  Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
