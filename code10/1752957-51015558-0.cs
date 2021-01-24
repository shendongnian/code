    private void getOrderId()
    {
        var orders_dt = conn.Select("orders", "MAX(order_id)").GetQueryData();
        if (orders_dt == null || orders_dt.Rows.Count == 0 || orders_dt.Rows[0][0] == null)
        {
            //Should not preemptively insert into the database
            order_no.Text = "1";
        }
        else
        {
            object cell = orders_dt.Rows[0][0];
            int order_id = (cell == DBNull.Value ? 0 : (int)cell + 1));
            order_no.Text = order_id.ToString();
        }
    }
