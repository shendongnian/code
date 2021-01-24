        while (!validJson) 
        {
            byte[] inStream = new byte[1024];
            stream.Read (inStream, 0, 1024);
            string jsonData = System.Text.Encoding.ASCII.GetString (inStream);
            jsonMsg = string.Concat (jsonMsg, jsonData);
            if (jsonMsg.Contains("}"))
            {
                validJson = true;
                //This part here is executed, but when I print(jsonMsg), it just prints the character "{" which gets transmitted in the first segment
            }
        }
