                    if (reader["PRODUCTION_LINE_CODE"].ToString() == "1")
                    {
                        return new List<string> { Status.Enable.ToString() };
                    }
                    else
                    {
                        return new List<string> {Status.Disable.ToString() };
                    }
