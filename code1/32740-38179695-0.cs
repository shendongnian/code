    public static bool IsConnectedToInternet()
            {
                bool returnValue = false;
                try
                {
    
                    int Desc;
                    returnValue = Utility.InternetGetConnectedState(out Desc, 0);
                }
                catch
                {
                    returnValue = false;
                }
                return returnValue;
            }
