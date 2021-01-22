    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        timer1.Start();
    }
    private string GetIndices()
    {
        string indices = "";
        foreach (int i in listView1.SelectedIndices)
        {
            indices += i.ToString() + ", ";
        }
        if (indices.Length > 0)
        {
            indices = indices.Substring(0, indices.Length - 2);
        }
        return indices;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        timer1.Stop();
        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") +
            ". Selected indices = " + GetIndices());
    }
