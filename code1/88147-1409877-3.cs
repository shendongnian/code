        public void Send(XmlDocument doc)
        {
            Send(doc.OuterXml);
        }
        private void Send(String str)
        {
            
            Byte[] sendBuf = utf8Encoding.GetBytes(str);
            Send(sendBuf);
        }
        private void Send(Byte[] sendBuf)
        {
            try
            {
                tcpClient.GetStream().Write(sendBuf, 0, sendBuf.Length);
                tcpClient.GetStream().WriteByte(0);
                tcpClient.GetStream().WriteByte(13); //very important to terminate XmlSocket data in this way, otherwise Flash can't read it.
                
            }
            catch (Exception e)
            {
                //something bad happened. cleanup?
                return;
            }
        }
