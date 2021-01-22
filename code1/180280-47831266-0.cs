    public async void StartProcessingButton_Click(object sender, EventArgs e)
    {
      // The Progress<T> constructor captures our UI context,
      //  so the lambda will be run on the UI thread.
      var progress = new Progress<int>(percent =>
      {
        textBox1.Text = percent + "%";
      });
    
      // DoProcessing is run on the thread pool.
      await Task.Run(() => DoProcessing(progress));
      textBox1.Text = "Done!";
    }
    
    public void DoProcessing(IProgress<int> progress)
    {
      for (int i = 0; i != 100; ++i)
      {
        Thread.Sleep(100); // CPU-bound work
        if (progress != null)
          progress.Report(i);
      }
    }
