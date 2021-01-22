    void dataLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)  
    {  
        DataLabel.Text = "Database Loaded";  
        var timer = new System.Windows.Forms.Timer();  
        timer.Interval = 5000;  
        timer.Tick += (o, a) =>  
        {  
            timer.Stop();
            DataLabel.Text = "";
        });
        timer.Start();
    }  
