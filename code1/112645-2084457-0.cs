            var csSetting = new ConnectionStringSettings(connStringName, connectionStringBuilder.ConnectionString, "System.Data.SqlClient");
            var readonlyField = typeof(ConfigurationElementCollection).GetField("bReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            readonlyField.SetValue(ConfigurationManager.ConnectionStrings, false);
            var baseAddMethod = typeof(ConfigurationElementCollection).GetMethod("BaseAdd",
                BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { typeof(ConfigurationElement) }, null);
            baseAddMethod.Invoke(ConfigurationManager.ConnectionStrings, new object[] { csSetting });
            readonlyField.SetValue(ConfigurationManager.ConnectionStrings, true);
            int finalCount = ConfigurationManager.ConnectionStrings.Count;
