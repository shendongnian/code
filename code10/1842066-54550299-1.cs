     if (_instance == null)
                    {
                        lock (SyncObject)
                        {
                            if (_instance == null)
                            {
                                _instance = new CustomQueueProcessor();
                            }
                        }
                    }
                    return _instance;
