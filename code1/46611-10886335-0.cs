    try
            {   
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential("username", "password", "DOMAIN");
                    client.DownloadFile(http_path, path);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
