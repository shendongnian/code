    protected void rlWorkItems_ItemReorder(object sender, ReorderListItemReorderEventArgs e)
        {
            List<VerticalMenuItem> list = (List<VerticalMenuItem>)Session["VerticalMenuItems"];
            List<VerticalMenuItem> newList = new List<VerticalMenuItem>();
            //if move one place - no matter top or bottom
            if (e.NewIndex - e.OldIndex == 1 || e.OldIndex - e.NewIndex == 1)
            {
                VerticalMenuItem oldItem = list[e.OldIndex];
                VerticalMenuItem newItem = list[e.NewIndex];
                list[e.NewIndex] = oldItem;
                list[e.OldIndex] = newItem;
                Session["VerticalMenuItems"] = list;
                return;
            }
            //From bottom to top
            if (e.OldIndex - e.NewIndex > 0)
            {
                VerticalMenuItem oldItem = list[e.OldIndex];                
                for (int i = 0; i < e.NewIndex; i++)
                {
                    newList.Add(list[i]);
                }
                list.Remove(oldItem);
                newList.Add(oldItem);
                for (int i = e.NewIndex; i < list.Count; i++)
                {
                    newList.Add(list[i]);
                }
                Session["VerticalMenuItems"] = newList;
                return;
            }
            //From top to bottom
            if (e.OldIndex - e.NewIndex < 0)
            {
                VerticalMenuItem oldItem = list[e.OldIndex];
                list.Remove(oldItem);
                for (int i = 0; i < e.NewIndex; i++)
                {
                    newList.Add(list[i]);
                }                
                newList.Add(oldItem);
                for (int i = e.NewIndex; i < list.Count; i++)
                {
                    newList.Add(list[i]);
                }
                Session["VerticalMenuItems"] = newList;
            }        
        }
