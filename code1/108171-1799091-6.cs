                using (var rsp = req.GetResponse())
                {
                    req.GetRequestStream().Close();
                    if (rsp != null)
                    {
                        using (var answerReader = 
                                    new StreamReader(rsp.GetResponseStream()))
                        {
                            var readString = answerReader.ReadToEnd();
                            //do whatever you want with it
                        }
                    }
                }
