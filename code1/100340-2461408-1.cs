    private void scatterView_Drop(object sender, SurfaceDragDropEventArgs e)
    {
        Console.WriteLine("Got drop: " + e.Cursor.Data);
        var newItem = new ScatterViewItem();
        // Rely on .ToString() on the data. A real app would do something more clever
        newItem.Content = e.Cursor.Data;
        // Place the new item at the drop location
        newItem.Center = e.Cursor.GetPosition(scatterView);
        // Add it to the scatterview
        scatterView.Items.Add(newItem);
    }
