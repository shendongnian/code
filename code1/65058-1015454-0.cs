    public class DbStatus
    {
        public static bool DbOnline()
        {
            const int MaxRetries = 10;
            int count = 0;
            while (count < MaxRetries)
            {
                try
                {
                    // Just access the database. any cheap query is ok since we don't care about the result.
                    return true;
                }
                catch (Exception ex)
                {
                    Thread.Sleep(30000);
                    count++;
                }
            }
            return false;
        }
    }
