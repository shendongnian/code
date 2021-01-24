                        Directory.GetDirectories(path, searchPattern).ToList().ForEach(
                        d =>
                        {
                            try
                            {
                                searchItems.Add(d);
                                searchItems.AddRange(Directory.GetDirectories(d, searchPattern, SearchOption.TopDirectoryOnly));
                            }
                            catch (UnauthorizedAccessException)
                            {
                                //do something when you are not authorized
                            }
                        });
