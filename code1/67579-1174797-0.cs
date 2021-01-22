        private static byte[] GeneratePayload(byte [] deviceToken, string message, string sound)
        {
            MemoryStream memoryStream = new MemoryStream();
            // Command
            memoryStream.WriteByte(0);
            byte[] tokenLength = BitConverter.GetBytes((Int16)32);
            Array.Reverse(tokenLength);
            // device token length
            memoryStream.Write(tokenLength, 0, 2);
            // Token
            memoryStream.Write(deviceToken, 0, 32);
            // String length
            string apnMessage = string.Format ( "{{\"aps\":{{\"alert\":{{\"body\":\"{0}\",\"action-loc-key\":null}},\"sound\":\"{1}\"}}}}",
                message,
                sound);
            byte [] apnMessageLength = BitConverter.GetBytes((Int16)apnMessage.Length);
            Array.Reverse ( apnMessageLength );
            // message length
            memoryStream.Write(apnMessageLength, 0, 2);
            // Write the message
            memoryStream.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(apnMessage), 0, apnMessage.Length);
            return memoryStream.ToArray();
        } // End of GeneratePayload
