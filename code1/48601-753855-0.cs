            ThreadPool.QueueUserWorkItem(state =>
                                             {
                                                 try
                                                 {
                                                     action();
                                                 }
                                                 catch (Exception ex)
                                                 {
                                                     OnException(ex);
                                                 }
                                             });
