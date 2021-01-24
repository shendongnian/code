    public List<MyData> GetMyData()
    {
        List<MyData> data = null;
        int delayMilliseconds = 100;
        bool waitingForResults = true;
        while (waitingForResults)
        {
            try
            {
                data = GetOrCreateChannel().GetMyData();
                waitingForResults = false; // if this executes, you've got your data and can exit
            }
            catch (Exception ex)
            {
                _log.error(ex);
                FixedBrokenService();
                Thread.Sleep(delayMilliseconds); // wait before retrying
                delayMilliseconds = delayMilliseconds * 2; // increase your delay
            }
        }
        return data;
    }
