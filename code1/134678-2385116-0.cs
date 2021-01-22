          private void SetProviderConnectionString(string connectionString)
        {
            // Set private property of Membership, Role and Profile providers.
            var connectionStringField = Membership.Provider.GetType().GetField("_sqlConnectionString", BindingFlags.Instance | BindingFlags.NonPublic);
            if (connectionStringField != null)
                connectionStringField.SetValue(Membership.Provider, connectionString);
            var roleField = Roles.Provider.GetType().GetField("_sqlConnectionString", BindingFlags.Instance | BindingFlags.NonPublic);
            if (roleField != null)
                roleField.SetValue(Roles.Provider, connectionString);
            var profileField = ProfileManager.Provider.GetType().GetField("_sqlConnectionString", BindingFlags.Instance | BindingFlags.NonPublic);
            if (profileField != null)
                profileField.SetValue(ProfileManager.Provider, connectionString);
        }
