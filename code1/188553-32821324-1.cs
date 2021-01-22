            Dictionary<int, string> ieUrlsDictionary = new Dictionary<int, string>();
            ShellWindows ieShellWindows = new SHDocVw.ShellWindows();
            string sProcessType;
            int i = 0;
            foreach (InternetExplorer ieTab in ieShellWindows)
            {
                sProcessType = Path.GetFileNameWithoutExtension(ieTab.FullName).ToLower();
                if (sProcessType.Equals("iexplore") && !ieTab.LocationURL.Contains("about:Tabs"))
                {
                    ieUrlsDictionary[i] = ieTab.LocationURL;
                    i++;
                }
            }
            
            //show list of url´s
            for (int j = 0; j < ieUrlsDictionary.Count; j++)
            {
                Console.WriteLine(ieUrlsDictionary[j]);
            }
