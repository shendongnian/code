    private void button1_Click(object sender, EventArgs e)
    {
        // this is the UI thread
        ThreadPool.QueueUserWorkItem(delegate(object state)
        {
            // this is the background thread
            // get the job done
            Thread.Sleep(5000);
            int result = 2 + 2;
            // next call is to the Invoke method of the form
            this.Invoke(new Action<int>(delegate(int res)
            {
                // this is the UI thread
                // update it!
                label1.Text = res.ToString();
            }), result);
        });
    }
