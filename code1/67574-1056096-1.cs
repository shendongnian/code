        public bool IsAddressAvailable(string address)
        {
            try
            {
                using(System.Net.WebClient client = new WebClient())
                {
                    client.DownloadData(address);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
