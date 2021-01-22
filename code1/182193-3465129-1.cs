    foreach (var item in items)
    {
        var item2 = item;
        item2.Menu.Click += (s, e) => graph.SetTrackedLine(item2.Slot);
        menuTrackLineWithMouse.DropDownItems.Add(item2.Menu);
    }
