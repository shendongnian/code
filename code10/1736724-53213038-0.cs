        private void btnUploadToServer_Click(object sender, EventArgs e)
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();
            if (connection == true)
            {
                //MessageBox.Show("Internet Available");
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        string filePath = @"C:\Users\SAKTHYBAALAN-PC\Desktop\app_sample.json";
                        var myUri = new Uri(@"http://your_address/path/file.php");
                        client.UploadFile(myUri, filePath);
                        client.Credentials = CredentialCache.DefaultCredentials;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                MessageBox.Show("Successfully Uploaded", "Success");
                btnExecuteURL.Enabled = true;
            }
            else
            {
                MessageBox.Show("There is no internet connection.\n Please make sure that you have an internet connection.", "No Internet");
            }
        }
