    async void Control_Click(object sender, EventArgs e)
    {
        if (_garbageMode)
        {
            _itemsToDelete.Add(sender);
        }
    }
