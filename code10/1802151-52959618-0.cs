    private void lblFile_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy; // Okay
        else
            e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }
