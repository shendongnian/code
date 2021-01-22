        public bool IsAddressAvailable(string address)
        {
            try
            {
                System.Net.WebClient client = new WebClient();
                client.DownloadData(address);
                return true;
            }
            catch
            {
                return false;
            }
        }
