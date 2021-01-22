    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
     foreach (string name in getNames()) 
     {
        MessageBox.Show(name);
     }
    }
    
    private IList<string> getNames()
    {
     //some code...
     List<string> names = new List<string>();
     names.Add("Scott");
     ..
     ...
     return names;
    }
