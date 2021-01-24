    //page1 load
    private void Load()
    {
        LoadOrdersAsync();
    }
    private async Task LoadOrdersAsync()
    {
        while (true)
        {
            //Creating SortedList
            var SortedOrderList = //add your logic
            RunOnUiThread( ()=>        
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
            });
            
            // don't run again for at least 3 seconds
            await Task.Delay(3000);
        }
    }
