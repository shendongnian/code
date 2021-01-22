    private void AddItemToListBox(ListBox listBox, object newItem)
        {
            int scrollToIndex = -1;
            bool scrollToEnd = false;
            //Work out if we should scroll to the end after adding a new item
            int lastIndex = listBox.IndexFromPoint(4, listBox.ClientSize.Height - 4);
            if ((lastIndex < 0) || (lastIndex == listBox.Items.Count - 1))
            {
                scrollToEnd = true;
            }
            //To prevent listbox jumping about as we delete and scroll
            listBox.BeginUpdate();
            //Work out if we have too many items and have to delete
            if (listBox.Items.Count >= MAX_LISTBOX_ITEMS)
            {
                //If deleting an item, and not scrolling to the end when new item added anyway,
                //then we will need to scroll to keep in the same place, work out new scroll index
                if (!scrollToEnd)
                {
                    scrollToIndex = listBox.TopIndex - 1;
                    if (scrollToIndex < 0)
                    {
                        scrollToIndex = 0;
                    }
                }
                //Remove top item
                listBox.Items.Remove(listBox.Items[0]);
            }
            //Add new item
            listBox.Items.Add(newItem);
            //Scroll if necessary
            if (scrollToEnd)
            {
                listBox.TopIndex = listBox.Items.Count - 1;
            }
            else if (scrollToIndex >= 0)
            {
                listBox.TopIndex = scrollToIndex;
            }
            listBox.EndUpdate();
        }
