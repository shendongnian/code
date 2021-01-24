    // BFM calling class
	public class BFM_v410Service
    {
        // The constructor and CreateRequest simeply create a complete request
        private BargainFinderMaxRQRequest service;
        private OTA_AirLowFareSearchRQ request;
        public OTA_AirLowFareSearchRS response;
        private string endpoint;
        public BFM_v410Service(string token, string pcc, string convId, string endpoint)
        {
            CreateRequest(pcc, true);
            this.endpoint = endpoint;
            service = new BargainFinderMaxRQRequest()
            {
                MessageHeader = new BargainFinderMaxRQ_3_4_0_Srvc.MessageHeader()
                {
                    From = new From()
                    {
                        PartyId = new PartyId[]
                    {
                        new PartyId()
                        {
                            Value = pcc
                        }
                    }
                    },
                    To = new To()
                    {
                        PartyId = new PartyId[]
                    {
                        new PartyId()
                        {
                            Value = endpoint
                        }
                    }
                    },
                    ConversationId = convId,
                    CPAId = pcc,
                    Service = new Service()
                    {
                        Value = "BargainFinderMaxRQ"
                    },
                    Action = "BargainFinderMaxRQ",
                    MessageData = new MessageData()
                    {
                        Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssK")
                    }
                },
                OTA_AirLowFareSearchRQ = request,
                Security = new Security()
                {
                    BinarySecurityToken = token
                }
            };
        }
        private void CreateRequest(string pcc, bool compressed)
        {
            request = new OTA_AirLowFareSearchRQ()
            {
                Version = "3.4.0",
                POS = new SourceType[]
                {
                    new SourceType()
                    {
                        PseudoCityCode = pcc,
                        RequestorID = new UniqueID_Type()
                        {
                            ID = "1",
                            Type = "1",
                            CompanyName = new CompanyNameType()
                            {
                                Code = "TN",
                                Value = "TN"
                            }
                        }
                    }
                },
                OriginDestinationInformation = new OTA_AirLowFareSearchRQOriginDestinationInformation[]
                {
                    new OTA_AirLowFareSearchRQOriginDestinationInformation()
                    {
                        RPH = "1",
                        Item = "2018-09-21T11:00:00",
                        ItemElementName = ItemChoiceType.DepartureDateTime,
                        OriginLocation = new OriginDestinationInformationTypeOriginLocation()
                        {
                            LocationCode = "MVD"
                        },
                        DestinationLocation = new OriginDestinationInformationTypeDestinationLocation()
                        {
                            LocationCode = "KRK"
                        }
                    },
                    new OTA_AirLowFareSearchRQOriginDestinationInformation()
                    {
                        RPH = "2",
                        Item = "2018-09-28T11:00:00",
                        ItemElementName = ItemChoiceType.DepartureDateTime,
                        OriginLocation = new OriginDestinationInformationTypeOriginLocation()
                        {
                            LocationCode = "KRK"
                        },
                        DestinationLocation = new OriginDestinationInformationTypeDestinationLocation()
                        {
                            LocationCode = "MVD"
                        }
                    }
                },
                TravelerInfoSummary = new TravelerInfoSummaryType()
                {
                    AirTravelerAvail = new TravelerInformationType[]
                    {
                        new TravelerInformationType()
                        {
                            PassengerTypeQuantity = new PassengerTypeQuantityType[]
                            {
                                new PassengerTypeQuantityType()
                                {
                                    Code = "ADT",
                                    Quantity = "1"
                                }
                            }
                        }
                    }
                },
                TPA_Extensions = new OTA_AirLowFareSearchRQTPA_Extensions()
                {
                    IntelliSellTransaction = new TransactionType()
                    {
                        RequestType = new TransactionTypeRequestType()
                        {
                            Name = "50ITINS"
                        },
                        CompressResponse = new TransactionTypeCompressResponse()
                        {
                            Value = compressed
                        }
                    }
                }
            };
        }
        public void Execute()
        {
            try
            {
                // Instanciate the Inspector
                BFMInspector inspector = new BFMInspector();
                // Select the URL you'll be sending the request. I've passed this as a parameter in the constructor
                EndpointAddress url = new EndpointAddress(new Uri(endpoint));
                // Create a binding, with a couple of characteristics, because of the size of the response
                Binding binding = new BasicHttpsBinding()
                {
                    MaxReceivedMessageSize = Int32.MaxValue,
                    MaxBufferSize = Int32.MaxValue
                };
                // Create the executable the BargainFinderMaxPortTypeClient variable, which will allow me to call the service
                BargainFinderMaxPortTypeClient execute = new BargainFinderMaxPortTypeClient(binding, url);
                // Add the middleware. Here's where ApplyClientBehavior is called behind the scene and adds itself
                execute.Endpoint.EndpointBehaviors.Add(inspector);
                // Call BFM and successfully get the response as an OTA_AirLowFareSearchRS object
                response = execute.BargainFinderMaxRQ(ref service.MessageHeader, ref service.Security, request);
                Console.WriteLine(response);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
