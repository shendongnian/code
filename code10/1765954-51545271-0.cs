                    var contactsParam =
                        new SqlParameter("@contacts", SqlDbType.Structured)
                        {
                            TypeName = "dbo.Contact",
                            Value = GetSqlDataRecordsContactsList(contacts)
                        };
                    command.Parameters.Add(new SqlParameter("@contacts", contactsParam));
