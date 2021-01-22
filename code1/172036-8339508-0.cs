     public static string ValidateImage(string absoluteUrl,string defaultUrl)
            { 
               Uri myUri=null; 
               if (Uri.TryCreate(absoluteUrl, UriKind.Absolute, out myUri))
                {
                    using (WebClient client = new WebClient())
                    {
                        try
                        {
                            using (Stream stream = client.OpenRead(myUri))
                            {
                                Image image = Image.FromStream(stream);
                                return (image != null) ? absoluteUrl : defaultUrl;
                            }
                        }
                        catch (ArgumentException)
                        {
                            return defaultUrl;
                        }
                        catch (WebException)
                        {
                            return defaultUrl;
                        }
                    }
                }
                else
                {
                    return defaultUrl;
                }
            }
 
