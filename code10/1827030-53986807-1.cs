    public void LoadOrders()
    {
        if (OrderListAdapter == null)
        {
            //Fill the DataSource of the ListView with the Array of Names
            OrderListAdapter = new OrderListAdapter(this, SortedOrderList);
            GridviewOrders.Adapter = OrderListAdapter;
        }
        else
        {
            OrderListAdapter.refresh(SortedOrderList);
        }
    }
