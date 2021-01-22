                        string[] brokenBaseUrl = Context.Url.TrimEnd('/').Split('/');
                        string[] brokenRootFolderPath = RootFolderPath.Split('/');
                        for (int x = 0; x < brokenRootFolderPath.Length; x++)
                        {
                            //if url doesn't already contain member, append it to the end of the string with / in front
                            if (!brokenBaseUrl.Contains(brokenRootFolderPath[x]))
                            {
                                if (x == 0)
                                {
                                    RootLocationUrl = Context.Url.TrimEnd('/');
                                }
                                else
                                {
                                    RootLocationUrl += String.Format("/{0}", brokenRootFolderPath[x]);
                                }
                            }
                        }
