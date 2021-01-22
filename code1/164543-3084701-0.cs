    public static void Larma(int personId)
        {
	        ThreadPool.QueueUserWorkItem(new WaitCallback(
                delegate(object unused)
                {
                    try
                    {
                        Larma_Thread(personId);
                    }
                    catch { /*log here */}
                }), personId);
        }
