    public void Refresh()
    {
        for (int i = ItemCollection.Count - 1; i >= 0; i--)
            ItemCollection.RemoveAt(i);
        for (int i = ButtonCollection.Count - 1; i >= 0; i--)
            ButtonCollection.RemoveAt(i);
        ItemList = new List<string> { "Updated item 1", "Updated item 2", "Updated item 3" };
        for (int i = 0; i < ItemList.Count; i++)
        {
            int copy = i;
            ButtonCollection.Add(new Button { Command = new Command(() => { SelectItem(copy); }), FontSize = 32, Text = (i + 1).ToString(), HeightRequest = 100, HorizontalOptions = LayoutOptions.FillAndExpand });
            ItemCollection.Add(new Label { Text = ItemList[i] });
        }
        System.Diagnostics.Debug.WriteLine(ItemCollection.Count);
        SelectItem(0);
    }
