            SPListTemplate listTemplate = null;
            while (listTemplate == null)
            {
                Thread.Sleep(1000);
                listTemplate = web.ListTemplates["Custom Access List"];
                if (listTemplate != null)
                {
                    web.Lists.Add("My new custom access list", "", listTemplate);
                }
            }
