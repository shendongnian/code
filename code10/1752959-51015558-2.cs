    private void getOrderId()
    {
        var orders_dt = conn.Select("orders", "MAX(order_id)").GetQueryData();
        if (orders_dt == null || orders_dt.Rows.Count == 0 || orders_dt.Rows[0][0] == DBNull.Value)
        {
            //Should not preemptively insert into the database
            order_no.Text = "1";
        }
        else
        {
            int order_id = orders_dt.Rows[0].Field<int>(0) + 1;
            order_no.Text = order_id.ToString();
        }
    }
