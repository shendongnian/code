        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            // Override payload
            string overrideXML = Properties.Resources.WCFOverride.Replace("---ACCOUNT_NUMBER---", "12345");
            // Create the reader
            XmlReader envelopeReader = XmlReader.Create(new StringReader(overrideXML));
            // Create the message using the reader
            System.ServiceModel.Channels.Message replacedMessage = System.ServiceModel.Channels.Message.CreateMessage(envelopeReader, int.MaxValue, reply.Version);
            replacedMessage.Headers.CopyHeadersFrom(reply.Headers);
            replacedMessage.Properties.CopyProperties(reply.Properties);
            reply = replacedMessage;
        }
