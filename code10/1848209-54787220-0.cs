    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        if(textBox1.Text == "Abrar" && textBox2.Text=="abrar")
        {
    
            //progressBar1.Visible = true;
            backgroundWorker1.ReportProgress(i);
            Thread.Sleep(3000);
            backgroundWorker1.ReportProgress(i * 2);
            Thread.Sleep(3000);
    
            backgroundWorker1.ReportProgress(i * 3);
            Thread.Sleep(3000);
            backgroundWorker1.ReportProgress(i * 4);
           
    
    
        }
        if(backgroundWorker1.CancellationPending)
        {
            e.Cancel = true;
            backgroundWorker1.ReportProgress(0);
            return;
        }
    
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
    
    }
    
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if(e.Cancelled)`enter code here`
        {
            label3.Text = "Cancelled";
        }
        else
        {
            label3.Text = "Login Successful";
            Form2 f = new Form2();
            f.Show();
            Form1 d1 = new Form1();
            d1.Hide();
            this,Hide();
        }
    }
    
    private void Login_Click(object sender, EventArgs e)
    {
        if(!backgroundWorker1.IsBusy)
        {
            backgroundWorker1.RunWorkerAsync();
    
    
        }
        else if(backgroundWorker1.IsBusy)
        {
            label3.Text = "Process is running";
        }
    
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
       // progressBar1.Visible = false;
    }
    
    private void Cancel_Click(object sender, EventArgs e)
    {
        if(backgroundWorker1.IsBusy)
        {
            backgroundWorker1.CancelAsync();
    
        }
    }
