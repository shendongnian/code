    private static Mutex m_Mutex;
     bool IsNew;
            m_Mutex = new Mutex(true, Application.ProductName, out IsNew);
            if (IsNew)
            {
                Application.Run(new Form1());
            }
