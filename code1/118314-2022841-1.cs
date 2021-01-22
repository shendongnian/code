    List<Order> orders = new List<Order>();
    using(SqlConnection cn = new SqlConnection("..."))
    using (SqlCommand cm = cn.CreateCommand())
    {
        cn.Open();
        cm.CommandText = "SELECT OrderId, OrderDate FROM Orders";
        SqlDataReader dr = cm.ExecuteReader();
        while (dr.Read())
        {
            orders.Add(new Order()
            {
                OrderId = dr.GetInt32(dr.GetOrdinal("OrderId")),
                OrderDate = dr.GetDateTime(dr.GetOrdinal("OrderDate"))
            });
        }
    }
