           private object dtfix(object o)
            {
                if (!(o is DateTime))
                {
                    return null;
                }
                else
                {
                    try
                    {
                        DateTime x = (DateTime)o;
                        x.AddDays(1);
                    }
                    catch
                    {
                        return null;
                    }
                    return o;
                }
            }
    
    param = new SqlParameter("duedate", SqlDbType.Date);
    param.Value = dtfix(myparm) ?? DBNull.Value;
