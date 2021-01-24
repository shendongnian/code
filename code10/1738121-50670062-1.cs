    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Net;
    using System.IO;
    using System.Xml.Linq;
    namespace WebService
    {
        class Program
        {
            /// <summary>
            /// Execute a Soap WebService call
            /// </summary>
            public static string Execute(string queryNo)
            {
                HttpWebRequest request = CreateWebRequest();
                XmlDocument soapEnvelopeXml = new XmlDocument();
                soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:customNAMESPACE=""http://webservice.com"">
                    <soapenv:Header>
                        <wsse:Security xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                            <wsse:UsernameToken>
                                <wsse:Username>USER</wsse:Username>
                                <wsse:CustomField>CODE</wsse:CustomField>
                            </wsse:UsernameToken>
                         </wsse:Security>
                      </soapenv:Header>
                      <soapenv:Body>
                         <customNAMESPACE:QueryByQueryNo>
                            <!--Optional:-->
                            <QueryByQueryNo>
                                <!--Optional:-->
                                <queryNo>" + queryNo + @"</queryNo>
                            </QueryByQueryNo>
                          </customNAMESPACE:QueryByQueryNo>
                      </soapenv:Body>
                    </soapenv:Envelope>");
    
                using (Stream stream = request.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
    
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        string soapResult = rd.ReadToEnd();
                        Console.WriteLine(soapResult);
                        return soapResult;
                    }
                }
            }
            /// <summary>
            /// Create a soap webrequest to [Url]
            /// </summary>
            /// <returns></returns>
            public static HttpWebRequest CreateWebRequest()
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(@"https://webservice.com/webservice?wsdl");
                webRequest.Headers.Add(@"SOAP:Action");
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";
                return webRequest;
            }
            static void Main(string[] args)
            {
                if (args.Length == 0 || args.Length > 1)
                {
                    System.Console.WriteLine("Please provide a query no");
                    System.Console.WriteLine("Usage: WebService.exe 3523423333");
                    return;
                }
                
                string output, XMLresponse;
                try
                {
                    XMLresponse = Execute(args[0]);
                    output = "Successful query";
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(XMLresponse);  // suppose that str string contains the XML data. You may load XML data from a file too.
                    XmlNodeList resultCodeList = xml.GetElementsByTagName("resultCode");
                    XmlNodeList resultNoList = xml.GetElementsByTagName("resultNo");
                    int i = 0;
                    var OutputTable = new DataTable();
                    OutputTable.Columns.Add("Result Code", typeof(string));
                    OutputTable.Columns.Add("Result No", typeof(string));
                    foreach (XmlNode xn in resultCodeList)
                    {
                        Console.WriteLine(resultCodeList[i].InnerText + "  " + resultNoList[i].InnerText);
                        OutputTable.Rows.Add(resultCodeList[i].InnerText, resultNoList[i].InnerText);
                        i++;
                    }
    
                }
                catch (System.Net.WebException exc)
                {
                    Console.WriteLine("HTTP POST request failed!");
                    output = "!!!HTTP POST request failed!!!";
                }
            }
        }
    }
