    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
        foreach (string name in getNames())
        {
            MessageBox.Show(name);
        }
    }
    
    private List<string> GetNames()
    {
        var names = new List<string>();
        names.Add("Kent");
        return names;
    }
