    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
        foreach (var item in ((Transport)e.Data.GetData(typeof(Transport))).Items)
        {
            System.Diagnostics.Debug.WriteLine(item.Name + " " + item.Description);
        }
    }
