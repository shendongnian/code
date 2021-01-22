            loader.WorkDelegate = delegate { 
                                             // get any data you want 
                                             for (int i = 0; i < 10; i++)
                                            {
                                                Thread.Sleep(100);
                                            }
                                           };
            loader.WorkCompleted = delegate
                                       {
                                           // access any control you want 
                                           MessageLabel.Text = "Completed";
                                            
                                       };
            loader.Execute();
