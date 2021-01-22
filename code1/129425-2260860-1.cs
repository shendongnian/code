    var items = new System.Collections.ArrayList(listboxFiles.Items);
    foreach (var item in items) {
        if (item.Equals("."))
            listboxFiles.Items.remove(item);
        …
    }
