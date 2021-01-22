    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") +
            ". Selected indices = " + GetIndices((ListView)sender));
    }
    
    private string GetIndices(ListView sender)
    {
        string indices = "";
        foreach (int i in sender.SelectedIndices)
        {
            indices += i.ToString() + ", ";
        }
    
        if (indices.Length > 0)
        {
            indices = indices.Substring(0, indices.Length - 2);
        }
    
        return indices;
    }
