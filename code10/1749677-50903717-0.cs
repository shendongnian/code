    public string ClientReceive()
        {
            try
            {
                stream = client.GetStream();
                byte[] data;
                data = new Byte[256];
                String responseData = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                responseData = responseData.Substring(0, responseData.Length-1); // This will remove the last character
                return responseData;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
                return null;
            }
        }
