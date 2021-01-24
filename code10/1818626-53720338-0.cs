        var username = txtusername.Text;
        var password = txtpassword.Text;
        string Token = "28956";
            var url = "https://mydomain.com.au/LoginVerification.php?";
            var var = "username=" + username + "&password=" + password + "&Token=" + Token ;
            var URL = url + var;
            //MessageBox.Show(URL);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            var responseFromServer = reader.ReadToEnd();
            //MessageBox.Show(responseFromServer);
            // Display the content.  
            if (responseFromServer == "\n  Allow")
            {
                MessageBox.Show("Success");           
            }
