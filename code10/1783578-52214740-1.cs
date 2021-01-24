            [TestMethod]
            public void TestGetReport()
            {
                // Developer AWS access key
                var accessKey = "[YOUR-ACCESS-KEY]";
    
                // Developer AWS secret key
                var secretKey = "[YOUR-SECRET-KEY]";
    
                // The client application name
                var appName = "MWS Reports API SAMPLE";
    
                // The client application version
                var appVersion = "1.0";
    
                // The endpoint for region service and version (see developer guide)
                // ex: https://mws.amazonservices.com
                var serviceURL = "https://mws.amazonservices.com";
    
                var config = new MarketplaceWebServiceConfig();
                config.ServiceURL = serviceURL;
    
                var client = new MarketplaceWebServiceClient(accessKey, secretKey, appName, appVersion, config);
    
                var request = new GetReportRequest();
                var sellerId = "[YOUR-SELLER-ID]";
                request.Merchant = sellerId;
                var mwsAuthToken = "[YOUR-MWS-AUTH-TOKEN]";
                request.MWSAuthToken = mwsAuthToken;
                request.ReportId = "[YOUR-REPORT-ID]";
    
                var path = request.ReportId + "_" + Guid.NewGuid();
                var thePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + string.Format("{0}.txt", path);
    
                request.Report = File.Open(thePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    
                //request.ReportTypeList = new TypeList { Type = new List<string> { "_GET_V2_SETTLEMENT_REPORT_DATA_XML_" } };
    
                try
                {
                    GetReportResponse response = null;
                    response = client.GetReport(request);
                    Console.WriteLine("Response:");
                    var rhmd = response.ResponseHeaderMetadata;
                    // We recommend logging the request id and timestamp of every call.
                    Console.WriteLine("RequestId: " + rhmd.RequestId);
                    Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                    var responseXml = response.ToXML();
                    Console.WriteLine(responseXml);
                    request.Report.Close();
                }
                catch (MarketplaceWebServiceException ex)
                {
                    // Exception properties are important for diagnostics.
                    ResponseHeaderMetadata rhmd = ex.ResponseHeaderMetadata;
                    Console.WriteLine("Service Exception:");
                    if (rhmd != null)
                    {
                        Console.WriteLine("RequestId: " + rhmd.RequestId);
                        Console.WriteLine("Timestamp: " + rhmd.Timestamp);
                    }
    
                    Console.WriteLine("Message: " + ex.Message);
                    Console.WriteLine("StatusCode: " + ex.StatusCode);
                    Console.WriteLine("ErrorCode: " + ex.ErrorCode);
                    Console.WriteLine("ErrorType: " + ex.ErrorType);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Message: " + ex.Message);
                }
            }
