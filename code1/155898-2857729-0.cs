    private void OnItemDragEnter(object sender, DragEventArgs e)
    {
        //Get the first format out of the list and try to cast it into the
        //desired type.
        var list = e.Data.GetData(e.Data.GetFormats()[0]) as IEnumerable<ListViewItem>;
        if (list != null)
        {
            e.Effect = DragDropEffects.Copy;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }
