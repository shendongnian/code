            String trimmedBody = itemNode.Attributes.GetNamedItem("ows_BodyAndMore").Value;
            String threadIndex = itemNode.Attributes.GetNamedItem("ows_ThreadIndex").Value;
            StringBuilder mesBody = new StringBuilder(1024);
            mesBody.AppendFormat("Message-ID: {0}\n", Guid.NewGuid().ToString());
            threadIndex = threadIndex.Substring(2);
            byte[] byteArray = FromHex(threadIndex);                        
            threadIndex = base64Encode(byteArray);
            string encoded = threadIndex;
            mesBody.AppendFormat("Thread-Index: {0}\n", encoded);
            mesBody.AppendFormat("Subject: {0}\n", title); //the ows_Title of the discussion - messages don't always have titles...
            mesBody.Append("Mime-Version: 1.0\n");
            mesBody.Append("Content-type: text/html; charset=UTF-8\n\n");
            mesBody.Append(body);
            mesBody.Append(trimmedBody);
            client.AddDiscussionBoardItem(ListName, Encoding.UTF8.GetBytes(mesBody.ToString()));
        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
        public string base64Encode(byte[] data)
        {
            try
            {
                byte[] encData_byte = data;
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Encode" + e.Message);
            }
        }
