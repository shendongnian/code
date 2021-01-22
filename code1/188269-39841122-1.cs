                byte[] response = null;
                using (WebClientCert client = new WebClientCert())
                {
                    response = client.UploadValues(postUri, PostFields);
                    HttpStatusCode code = client.StatusCode;
                    string description = client.StatusDescription;
                    //Use this information
                }
