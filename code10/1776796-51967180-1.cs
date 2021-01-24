     /// <summary>
                /// Setup connection to MQ queue manager using XMS .NET
                /// </summary>
                private void ibmmqSetupConnection()
                {
                    XMSFactoryFactory factoryFactory;
                    IConnectionFactory cf;
                    IDestination destination;
                    IMessageConsumer consumerAsync;
                    MessageListener messageListener;
                    // Get an instance of factory.
                    factoryFactory = XMSFactoryFactory.GetInstance(XMSC.CT_WMQ);
            
                    // Create WMQ Connection Factory.
                    cf = factoryFactory.CreateConnectionFactory();
            
                    // Set the properties
                    cf.SetStringProperty(XMSC.WMQ_HOST_NAME, "host.ibm.com");
                    cf.SetIntProperty(XMSC.WMQ_PORT, 1414);
                    cf.SetStringProperty(XMSC.WMQ_CHANNEL, "QM.SVRCONN");
                    cf.SetIntProperty(XMSC.WMQ_CONNECTION_MODE, XMSC.WMQ_CM_CLIENT);
                    cf.SetStringProperty(XMSC.WMQ_QUEUE_MANAGER, "QM1");
                    cf.SetStringProperty(XMSC.USERID, "myuserid");
                    cf.SetStringProperty(XMSC.PASSWORD, "passw0rd");
            
                    // Create connection.
                    connectionWMQ = cf.CreateConnection();
                    // Create session with client acknowledge so that we can acknowledge 
                    // only if message is sent to Azure Service Bus queue
                    sessionWMQ = connectionWMQ.CreateSession(false, AcknowledgeMode.ClientAcknowledge);
                    // Create destination
                    destination = sessionWMQ.CreateQueue("INPUTQ");
                    // Create consumer
                    consumerAsync = sessionWMQ.CreateConsumer(destination);
            
                    // Setup a message listener and assign it to consumer
                    messageListener = new MessageListener(OnMessageCallback);
                    consumerAsync.MessageListener = messageListener;
            
                    // Start the connection to receive messages.
                    connectionWMQ.Start();
            
                    // Wait for messages till a key is pressed by user
                    Console.ReadKey();
            
                    // Cleanup
                    consumerAsync.Close();
                    destination.Dispose();
                    sessionWMQ.Dispose();
                    connectionWMQ.Close();
                }
