    private void GoButton_Click(object sender, EventArgs e)
    {
        var IDs = BaseCollection.SelectMany(u => u.Value);
        foreach (string id in IDs)
        {
            var Items = BaseCollection.Select((k, v) => new { k, v });
            var Item = Items.SelectMany(i => i.k.Value).Select(a => a).Where(a => a == id);
            int Count = Item.Count();
            if(Count > 1) // Duplicate Found, Figure out what to do...
        }
    }
