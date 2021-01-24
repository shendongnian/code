    private void btnDoAllTask_Click(object sender, EventArgs e)
    {
        var listUsername = new string[] { "one", "two", "three" };
        foreach (var username in listUsername)
        {
            MyUsername(username);
        }
    }
