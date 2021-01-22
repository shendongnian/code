        public void WriteInput(SoapMessage message)
        {
            //Begin Edit
            oldStream.Position = 0;
            _requestXml = new StreamReader(_oldStream).ReadToEnd();
            _start = DateTime.UtcNow;
            //End Edit
            //Begin Original Code
            oldStream.Position = 0;
            Copy(oldStream, newStream);
            var fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
            var w = new StreamWriter(fs);
            var soapString = (message is SoapServerMessage) ? "SoapRequest" : "SoapResponse";
            w.WriteLine("-----" + soapString + " at " + DateTime.Now);
            w.Flush();
            newStream.Position = 0;
            Copy(newStream, fs);
            w.Close();
            newStream.Position = 0;
        }
