        public void WriteOutput(SoapMessage message)
        {
            //Begin Edit
            var responseXml = new StreamReader(newStream).ReadToEnd();
            newStream.Position = 0;
            //Start process for saving to DB 
            //"_requestXml" = Original Request Soap Message
            //"responseXml" = Service Returned Response
            //"_start" = Request Start Time
            //message.MethodInfo.Name = I save this so I know what method from     
            //message.Url = I save this so I know the original ASMX that was hit
            //End Edit
            //Begin Original Code
            newStream.Position = 0;
            var fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            var w = new StreamWriter(fs);
            var soapString = (message is SoapServerMessage) ? "SoapResponse" : "SoapRequest";
            w.WriteLine("-----" + soapString + " at " + DateTime.Now);
            w.Flush();
            Copy(newStream, fs);
            w.Close();
            newStream.Position = 0;
            Copy(newStream, oldStream);
        }
