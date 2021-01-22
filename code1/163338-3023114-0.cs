    using (var sqlConnection = new SqlConnection(Lfepa.Itrs.Framework.Configuration.ConnectionString))
            {
                sqlConnection.Open();
                var selectCommand = new SqlCommand(Lfepa.Itrs.Data.Database.Commands.dbo.SettingsSelAll, sqlConnection);
                using (var reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string val = reader.GetString(reader.GetOrdinal(SettingKeyColumnName));
                        if ( string.IsNullOrEmpty(val) )
                            continue;
                        if ( val.Equals(DatabaseVersionKey, StringComparison.OrdinalIgnoreCase))
                            DatabaseVersion = new Version(val);
                        else if (val.Equals(ApplicationVersionKey, StringComparison.OrdinalIgnoreCase))
                            ApplicationVersion = new Version(val);
                        }
                    }
                }
                if (DatabaseVersion == null)
                    throw new ApplicationException("Colud not load Database Version Setting from the database.");
                if (ApplicationVersion == null)
                    throw new ApplicationException("Colud not load Application Version Setting from the database.");
            }
