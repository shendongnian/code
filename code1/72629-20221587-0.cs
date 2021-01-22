    void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Data) == false)
            {
                new Thread(() =>
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        // Add you code here
                    }));
                }).Start();
            }
        }
