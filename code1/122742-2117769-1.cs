            using(SPWeb web = site.OpenWeb())
            {
                SPListTemplate listTemplate = null;
                while (listTemplate == null)
                {
                    Thread.Sleep(1000);
                    try
                    {
                        listTemplate = web.ListTemplates["Custom Access List"];
                        if (listTemplate != null)
                        {
                            // here your code 
                            web.Lists.Add("My new custom access list", "", listTemplate);
                        }
                    }
                    catch
                    {
                        web = site.OpenWeb();
                    }
                }
            }
