            string url = "http://XXXXXX/SampleWebService/Service.asmx";
            string methodName = "GetEmployeesJSONByID";
            Dictionary<string, string> Params = new Dictionary<string, string>();
            HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create(url);
            string soapStr =
                       @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                           xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                           xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                          <soap:Body>
                            <{0} xmlns=""http://tempuri.org/"">
                              {1}
                            </{0}>
                          </soap:Body>
                        </soap:Envelope>";
            webreq.Headers.Add("SOAPAction", "\"http://tempuri.org/GetEmployeesJSONByID\"");
            webreq.ContentType = "text/xml;charset=\"utf-8\"";
            webreq.Accept = "text/xml";
            webreq.Method = "POST";
            // <"name">Name of the WebMethod parameter (case sensitive)</param>
            // <"value">Value to pass to the paramenter</param>
            Params.Add("name", "value"); // Add parameterName & Value to dictionary
            using (Stream stm = webreq.GetRequestStream())
            {
                string postValues = "";
                foreach (var param in Params)
                {
                    postValues += string.Format("<{0}>{1}</{0}>", param.Key, param.Value);
                }
                soapStr = string.Format(soapStr, methodName, postValues);
                using (StreamWriter stmw = new StreamWriter(stm))
                {
                    stmw.Write(soapStr);
                }
            }
            StreamReader responseReader = new StreamReader(webreq.GetResponse().GetResponseStream());
            string result = responseReader.ReadToEnd();
   
