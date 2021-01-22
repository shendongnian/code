     public int Test()
            {
                try
                {
                    int h = 0;
                    h = 100;
                    throw new Exception();
                    return h;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
