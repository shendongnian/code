        private void RegisterHttpHandler()
        {
            
            IWebApplication webApplication =
                (IWebApplication)this.GetService(typeof(IWebApplication));
            if (webApplication != null)
            {
                Configuration configuration = webApplication.OpenWebConfiguration(false);
                if (configuration != null)
                {
                    HttpHandlersSection section =
                        (HttpHandlersSection)configuration.GetSection(
                        "system.web/httpHandlers");
                    if (section == null)
                    {
                        section = new HttpHandlersSection();
                        ConfigurationSectionGroup group =
                            configuration.GetSectionGroup("system.web");
                        if (group == null)
                        {
                            configuration.SectionGroups.Add("system.web",
                                new ConfigurationSectionGroup());
                        }
                        group.Sections.Add("httpHandlers", section);
                    }
                    section.Handlers.Add(Action);
                    configuration.Save(ConfigurationSaveMode.Minimal);
                }
            }
        }
