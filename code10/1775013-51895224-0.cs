            catch (WebException webEx)
            {
                if (0 != webEx.Response.ContentLength)
                {
                    using (var stream = webEx.Response.GetResponseStream())
                    {
                        if (null != stream)
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var errorMsg = reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
