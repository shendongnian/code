    pb.Dispatcher.Invoke(
                      System.Windows.Threading.DispatcherPriority.Normal,
                      new Action(
                        delegate()
                        {
                            if (pb.Value >= 200)
                                pb.Value = 0;
                            pb.Value += 10;
                        }
                    ));
