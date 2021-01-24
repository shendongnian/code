                    RfcConfigParameters para = new RfcConfigParameters();
                    para.Add(RfcConfigParameters.Name, destinationname);
                    para.Add(RfcConfigParameters.AppServerHost, appServer); // If they are using SAP Router then please refer SAP documentation on Public and PrivateIP address details as you need both
                    para.Add(RfcConfigParameters.SystemNumber, systemNumber);
                    para.Add(RfcConfigParameters.SystemID, systemID);
                    para.Add(RfcConfigParameters.User, user);// "RFCUSER"); 
                    para.Add(RfcConfigParameters.Password, password);
                    para.Add(RfcConfigParameters.Client, client);
                    para.Add(RfcConfigParameters.Language, language);// "EN");
                    RfcDestination dest = RfcDestinationManager.GetDestination(para);
                    // Test connection
                    dest.Ping();
                    RfcSessionManager.BeginContext(dest);
                    var rfcFunction = dest.Repository.CreateFunction("RFCFunctionName");
                    rfcFunction.SetValue("INPUT PARAMETER NAME", "Value");
                    // Call the function
                    rfcFunction.Invoke(dest);
