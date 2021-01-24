     int maxRetry = 10;
            for (int i = 0; i<=maxRetry; i++)
            {
                try
                {
                    //DO YOUR STUFF
                }
                catch (Exception)
                {
                    //OH NOES! ERROR!
                    continue; //RETRY!
                }
            }
