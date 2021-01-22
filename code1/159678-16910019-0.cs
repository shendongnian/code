    List<string> results = new List<string>();
            DirectoryInfo di = new DirectoryInfo(System.Configuration.ConfigurationManager.AppSettings["PathToSearchableViews"]);
            //get all view directories except the shared
            foreach (DirectoryInfo d in di.GetDirectories().Where(d=>d.Name != "Shared"))
            {
                //get all the .cshtml files
                foreach (FileInfo fi in d.GetFiles().Where(e=>e.Extension  == ".cshtml"))
                {
                    //check if cshtml file and exclude partial pages
                    if (fi.Name.Substring(0,1) != "_")
                    {
                        MatchCollection matches;
                        bool foundMatch = false;
                        int matchCount = 0;
                        using (StreamReader sr = new StreamReader(fi.FullName))
                        {
                            string file = sr.ReadToEnd();
                            foreach (string word in terms)
                            {
                                Regex exp = new Regex("(?i)" + word.Trim() + "(?-i)");
                                matches = exp.Matches(file);
                                if (matches.Count > 0)
                                {
                                    foundMatch = true;
                                    matchCount = matches.Count;
                                }
                            }
                            //check match count and create links
                            //
                            //
                        }
                    }
                }
            }
            return results;
