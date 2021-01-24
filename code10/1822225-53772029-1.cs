        private void button2_Click(object sender, EventArgs e)
        {
            // Use the 'client' variable to call operations on the service.
            CARateRequest mrrequest = new CARateRequest();
            mrrequest.City = "Anaheim";
            mrrequest.State = "CA";
            mrrequest.StreetAddress = "1313 Disneyland Dr";
            mrrequest.ZipCode = 92802;
            CATaxRateAPIClient client = new CATaxRateAPIClient();
            var myrate = client.GetRate(mrrequest);
            MessageBox.Show(myrate.CARateResponses[0].Responses[0].Rate.ToString()); 
            // Close the client.
            client.Close();
        }
