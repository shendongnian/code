    int a = 0;
            try
            {
                int x = 4;
                int y ;
                try
                {
                    y = x / a;
                }
            
                catch (Exception e)
                {
                    Console.WriteLine("inner ex");
                    //throw;   // Line 1
                    //throw e;   // Line 2
                    //throw new Exception("devide by 0");  // Line 3
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
