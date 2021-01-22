        public bool DoesImageExistRemotely(string uriToImage)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriToImage);
           
                request.Method = "HEAD";
                try
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (WebException) { return false; }
                catch
                {
                    return false;
                }
        }
