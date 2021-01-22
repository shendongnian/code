    private string[] status;
    private void btnCompleted_Click(object sender, EventArgs e)
    {
        for (int i = 2; i < status.Length; i++)
        {
            if (status[i] == "Complete")
                lstReports.Items.Add(status[i-2]);
        }
    }
    private void Reports_Load(object sender, EventArgs e)
    {
        status = File.ReadAllLines("percent.txt");
    }
