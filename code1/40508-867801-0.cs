        /// <summary>
        /// Encrypts a Config section from the given Configuration object
        /// </summary>
        /// <param name="sectionKey">Path to the section to Encrypt</param>
        /// <param name="config">Configuration</param>
        public static void EncryptConfigSection(String sectionKey, Configuration config)
        {
            ConfigurationSection section = config.GetSection(sectionKey);
            if (section != null)
            {
                if (!section.SectionInformation.IsProtected)
                {
                    if (!section.ElementInformation.IsLocked)
                    {
                        section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                        section.SectionInformation.ForceSave = true;
                        config.Save(ConfigurationSaveMode.Full);
                    }
                }
            }
        }
