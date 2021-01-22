        NameValueCollection values = new NameValueCollection();
            values.Add("TextBox1", "value1");
            values.Add("TextBox2", "value2");
            values.Add("TextBox3", "value3");
            string Url = urlvalue.ToLower();
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    //  client.Headers.Add("Content-Type", "multipart/form-data");
                   // byte[] result = client.UploadValues(Url,  values);
                      byte[] result = client.UploadValues(Url, "POST", values);
                    string ResultAuthTicket = Encoding.UTF8.GetString(result);
                    client.Dispose();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
