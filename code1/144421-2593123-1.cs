        private static void ModifyConnectionStrings()
        {
            // Change the value in the config file first
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            const string newCnnStr = "server=(local);database=MyDb;user id=user;password=secret";
            config.ConnectionStrings.ConnectionStrings["MyProject.Properties.Settings.MyConnectionString"].ConnectionString = newCnnStr;
            config.Save(ConfigurationSaveMode.Modified, true);
            // Now edit the in-memory values to match
            Properties.Settings.Default["MyConnectionString"] = newCnnStr;
        }
