    public void getRobots()
    {
        WebClient wClient = new WebClient();
        string robotText;
        string[] robotLines;
        System.Text.StringBuilder robotStringBuilder;
        robotText = wClient.DownloadString(String.Format("http://{0}/robots.txt", urlBox.Text));
        robotLines = robotText.Split(Environment.NewLine);
        robotStringBuilder = New StringBuilder();
        foreach (string line in robotLines)
        {
            robotStringBuilder.Append(line);
            robotStringBuilder.Append(Environment.NewLine);
        }
        textbox1.Text = robotStringBuilder.ToString();
    }
