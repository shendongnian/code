            var privCert = new X509Certificate2(@"c:\temp\test.p12", "testpass");
            // privCert.Verify() => FALSE!  WHY???
            if (privCert.Verify())  Console.WriteLine("true");
            else                    Console.WriteLine("false");
                        // create Web Request and set CLient Certificate für the authentication
            HttpWebRequest request = CreateWebRequest();
            request.ClientCertificates.Add(privCert);
            // Create SOAP Message for PING Command
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                                    <soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ws=""http://ws.soap.transfer.services.sedna.ser.com/"">
                                        <soap:Header/>
                                        <soap:Body>
                                            <ws:ping>
                                                <sessionUUID>something</sessionUUID>
                                            </ws:ping>
                                        </soap:Body>
                                    </soap:Envelope>");
            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
            
            Console.WriteLine("Credentials of request = " + request);
            // Send Command to Webservice
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        Console.WriteLine(soapResult);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("\nTaste!");
            Console.ReadKey();
        }
        static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://doxapd01.zit.commerzbank.com:8443/soapWebService");
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
