        private void Form1_Load(object sender, EventArgs e)        
        {
            try
            {
                // Create Request
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"http://192.168.0.181/axis-cgi/com/ptz.cgi?move=up");
                
                // Create Client
                WebClient client = new WebClient();
                // Assign Credentials
                client.Credentials = new NetworkCredential("root", "a");
                // Grab Data
                string htmlCode = client.DownloadString(@"http://192.160.0.1/axis-cgi/com/ptz.cgi?move=up");
                // Display Data
                MessageBox.Show(htmlCode);
            }
            catch (WebException ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
