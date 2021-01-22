    private ArrayList statusArray = new ArrayList();
    private void btnCompleted_Click(object sender, EventArgs e) {
        for (int i = 0; i < statusArray.Count; i++)
        {
            if (statusArray[i].Equals("Complete"))
                lstReports.Items.Add(statusArray[i-2]);
        }
    }
    private void Reports_Load(object sender, EventArgs e)
    {
        // declare variables
        string inValue;
        string data;
        inFile = new StreamReader("percent.txt");
        // Read each line from the text file
        while ((inValue = inFile.ReadLine()) != null)
        {
            data = Convert.ToString(inValue);
            statusArray.Add(inValue);
        }
        // Close the text file
        inFile.Close();
    }
