    Task.Run(() =>
    {
        Dispatcher.Invoke(() =>
        {
            MainLine.Text = "Running for " + customer;
            DataInput.Text = "Running Data input.";
        });
        ExecuteProcess(Baseloco + "01_DataInput.bat");
        Dispatcher.Invoke(() => Mailsort.Text = "Running Mailsort.");
        ExecuteProcess(Baseloco + "02_Mailsort.bat");
        Dispatcher.Invoke(() => SampleandRecon.Text = "Running sample + recon.");
        ExecuteProcess(Baseloco + "03_SampleandRecon.bat");
    });
