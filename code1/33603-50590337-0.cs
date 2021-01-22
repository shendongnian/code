       private void ExceptionTest()
        {
            try
            {
                int j = 0;
                int i = 5;
                i = 1 / j;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                var stList = ex.StackTrace.ToString().Split('\\');
                Console.WriteLine("Exception occurred at " + stList[stList.Count() - 1]);
            }
        }
