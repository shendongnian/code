                    try
                    {
                        // must be numeric value
                        double d = double.Parse(s);
                        // max of two decimal places
                        if (s.IndexOf(".") >= 0)
                        {
                            if (s.Length > s.IndexOf(".") + 3)
                                return false;
                        }
                        return true;
                    catch
                    {
                        return false;
                    }
