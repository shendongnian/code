                string[] directories = myStringWithLotsOfFolders.Split(Path.DirectorySeparatorChar);
                string previousEntry = string.Empty;
                if (null != directories)
                {
                    foreach (string direc in directories)
                    {
                        string newEntry = previousEntry + Path.DirectorySeparatorChar + direc;
                        if (!string.IsNullOrEmpty(newEntry))
                        {
                            if (!newEntry.Equals(Convert.ToString(Path.DirectorySeparatorChar), StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine(newEntry);
                                previousEntry = newEntry;
                            }
                        }
                    }
                }
