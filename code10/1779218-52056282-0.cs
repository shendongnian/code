    public double ListViewHeight
    {
        get
        {
            if (MyItemsList!= null)
            {
                double listViewHeight = MyItemsList.Count * RowHeight;
                if (CanLoadMoreNotifications)
                {
                    listViewHeight += RowHeight;
                }
                return listViewHeight;
            }
            return 0;
        }
    }
