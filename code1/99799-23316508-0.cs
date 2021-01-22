    The error occurred here:
    #if !WITHOUT_OBJECTLISTVIEW
            /// <summary>
            /// Get the nth item from the given listview, which is in virtual mode.
            /// </summary>
            /// <param name="lv">The ListView in virtual mode</param>
            /// <param name="n">index of item to get</param>
            /// <returns>the item</returns>
            override protected ListViewItem GetVirtualItem(ListView lv, int n)
            {
    // Invalid Cast happens here
                return ((VirtualObjectListView)lv).MakeListViewItem(n);
            }
