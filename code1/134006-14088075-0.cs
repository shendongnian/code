                var tmp = AutoBalanceTriggered;
                if (tmp != null)
                {
                    var args = new CancelEventArgs();
                    foreach (EventHandler<CancelEventArgs> t in tmp.GetInvocationList())
                    {
                        t(this, args);
                        if (args.Cancel)              // a client cancelled the operation
                        {
                            break;
                        }
                    }
                }
 
