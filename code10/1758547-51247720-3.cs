    private void ReleaseMemory_Click(object sender, RoutedEventArgs e)
    {
        foreach (System.IO.MemoryStream memoryStream in MemoryStreamCollection)
        {
            memoryStream.Dispose();
        }
        MemoryStreamCollection = null;
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        MessageBox.Show("Done");
    }
