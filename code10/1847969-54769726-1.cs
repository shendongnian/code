    // declare as async
    private async void btnGenerate_Click(object sender, EventArgs e)
    {
        btnGenerate.Enabled = false;
        await Task.Run(() => {
                    Data = DataLoader.GetData(Environment.UserName); // stored procedure execution 
                    if (Data != null)
                    {
                        GenerateExcel(Data);
                        GenerateSingleExcel(Data);
                    } 
                });    
        // this is now executed back on the UI thread
        progressBar1.Visible = false;// ProgressBarStyle.Marquee 
        btnGenerate.Enabled = true;   
    }
    
