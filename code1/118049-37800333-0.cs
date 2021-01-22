     public Form1 GetFormInstance
     {
            get
            {
                lock (MyLock)
                {
                    if (_Instance == null || _Instance.IsDisposed)
                    {
                        _Instance = new Form1();
                    }
                    else
                    {
                        _Instance.BringToFront();
                    }
                    return Form1._Instance;
                }
            }
     }
