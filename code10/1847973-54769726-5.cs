    // declare as async
    private async void btnGenerate_Click(object sender, EventArgs e)
    {
        btnGenerate.Enabled = false;
        Data = await Task.Run(() => {
                    var data = DataLoader.GetData(Environment.UserName); // stored procedure execution 
                    if (data != null)
                    {
                        GenerateExcel(Data);
                        GenerateSingleExcel(Data);
                    }
                    return data; // as suggested by Vlad, don't set Data on this thread
                });    
        // this is now executed back on the UI thread
        progressBar1.Visible = false;// ProgressBarStyle.Marquee 
        btnGenerate.Enabled = true;   
    }
    
