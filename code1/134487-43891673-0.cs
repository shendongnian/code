    if (!IsReadOnly)
            {
                T newobj;
                bool Done;
                try
                {
                    newobj = DataPortal.Update<T>(this);
                    List<string> keys = new List<string>(BasicProperties.Keys);
                    foreach (string key in keys)
                    {
                        BasicProperties[key] = newobj.BasicProperties[key];
                    }
                    Done = true;
                }
                catch (DataPortalException)
                {
                    // TODO: Implement DataPortal.Update<T>() recovery mechanism
                    Done = false;
                }
                finally
                {
                    if (newobj != null && Done == false)
                    {
                        List<string> keys = new List<string>(BasicProperties.Keys);
                        foreach (string key in keys)
                        {
                            BasicProperties[key] = newobj.BasicProperties[key];
                        }
                    }
                }
            }
