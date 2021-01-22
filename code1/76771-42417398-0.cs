                if (regKey != null)
                {
                    string[] valueNames = regKey.GetSubKeyNames();
                    for (int i = 0; i < valueNames.Length; i++)
                    {
                        using (RegistryKey key = regKey.OpenSubKey(valueNames[i], true))
                        {
                            string[] names = key.GetValueNames();
                            for (int e = 0; e < names.Length; e++)
                            {
                                if (names[e] == "LoggedOnSAMUser")
                                {
                                    if (key.GetValue(names[e]).ToString() == currentUserName)
                                        SID = key.GetValue("LoggedOnUserSID").ToString();
                                }
                            }
                        }
                    }
                }
            }
