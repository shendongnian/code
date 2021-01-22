            bool shouldRetry = true;
            do {
                try
                {
                    Stream newStream = myHttpWebRequest.GetRequestStream();
                    newStream.Write(byteArray, 0, byteArray.Length);
                    newStream.Close();
                    HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                    shouldRetry = false;
                    response.Close();
                    tries++;
                    status = response.StatusDescription;
                }
                catch (WebException e)
                {
                    tries++;
                    if (tries >= 5)
                    {
                        throw e;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            } while (shouldRetry);
