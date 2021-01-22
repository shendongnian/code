                ThreadPool.QueueUserWorkItem((object state) =>
                {
                    Thread.Sleep(1);
                    try
                    {
                        send();
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                });
