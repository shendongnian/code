    public void DoSomething()
    {
        {
            Font font1;
            try
            {
                font1 = new Font("Arial", 10.0f);
                // Draw some text here
            }
            finally
            {
                IDisposable disp = font1 as IDisposable;
                if (disp != null) disp.Dispose();
            }
        }
    }
   
