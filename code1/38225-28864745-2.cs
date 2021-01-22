    ListItemCollection collection = new ListItemCollection();
                foreach (ListItem item in ListBox1.Items)
                {
                    if (item.Selected && !collection.Contains(item))
                        collection.Add(item);
                }
