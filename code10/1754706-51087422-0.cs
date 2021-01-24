       string[] subirectories = Directory.GetDirectories(directory);
                    foreach (string d in subirectories)
                    {
                        if (Regex.IsMatch(d, @"2-Storage", RegexOptions.IgnoreCase))
                        {
                            containsStorage = true;
                            string[] subSubDirectories = Directory.GetDirectories(d);
                            foreach (string ad in subSubDirectories)
                            {
                                if (Regex.IsMatch(ad, @"! Issued Packages", RegexOptions.IgnoreCase))
                                {
                                    containsIssued = true;
                                }
                            }
                        } 
                    }
