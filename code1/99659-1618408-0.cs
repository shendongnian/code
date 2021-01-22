    private void backgroundWorker_DoWork(object sender, AlbumInfoEventArgs e)
    {
        // Check with an element on the form whether this is a cross thread call
        if (dataGridView.InvokeRequired)
        {
            dataGridView.Invoke((MethodInvoker)delegate { AddToGrid(e.AlbumInfo); });
        }
        else
        {
            AddToGrid(e.AlbumInfo);
        }
    }
