    Thread th = new Thread(() =>
                    {
                        while (true)
                        {
                            bool allReadComplete = true;
    
                            foreach (IDataProvider provider in lstDataProviders)
                            {
                                provider.StartReading();
    
                                if (provider.FinishedReading)
                                  allReadComplete = allReadComplete && provider.FinishedReading;
                                else
                                  allReadComplete = provider.FinishedReading;
                            }
    
                            // to induce some context switching
                            Thread.Sleep(0);
    
                            if (allReadComplete)
                                break;
                        }
    
                        Console.WriteLine("Thread Exiting");
    
                    });
                th.IsBackground = true;
                th.Start();
