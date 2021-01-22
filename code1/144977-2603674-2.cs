    string xml = @"<?xml version=""1.0""?>
                    <Report1>
                      <Orientation>Landscape</Orientation>
                      <ReportParameter1>Page1</ReportParameter1>
                      <ReportParameter2>Colorado</ReportParameter2>
                    </Report1>";
                
                ///Create stream for serializer and put there our xml
                MemoryStream  str = new MemoryStream(ASCIIEncoding.ASCII.GetBytes(xml));
    
                ///Getting type that we are expecting. We are doing it by passing proper namespace and class name string
                Type expectingType = Assembly.GetExecutingAssembly().GetType("ConsoleApplication1.Report1");
    
                XmlSerializer ser = new XmlSerializer(expectingType);
    
                ///Deserializing the xml into the object
                object obj = ser.Deserialize(str);
    
                ///Now we have our report instance initialized
                Report1 report = obj as Report1;
