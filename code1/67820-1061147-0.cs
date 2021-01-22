            bool gotList;
            List<string> files = new List<string>();
            using (SvnClient client = new SvnClient())
            {
                Collection<SvnListEventArgs> list;
                gotList = client.GetList(projectPath, out list);
                if (gotList)
                {
                    foreach (SvnListEventArgs item in list)
                    {
                        files.Add(item.Path);
                    }
                }
            }
