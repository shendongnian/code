    String qr = "SELECT Id, CONVERT(varchar, OrderItemId) AS Product, Quantity,CONVERT(varchar,CustomerId) AS Customer, ReturnRequestStatusId as'Return Request Status', CreatedOnUtc as Date FROM ReturnRequest";
            DataTable dtr = new DataTable();
            tp.populatedt(qr, dtr);
            dgvReturnRequests.DataSource = dtr;
    
            DataGridViewTextBoxColumn ord = new DataGridViewTextBoxColumn();
            ord.HeaderText = "Order #";
            ord.Name = "OrderCol";
            dgvReturnRequests.Columns.Insert(4, ord);
    
            foreach (DataGridViewRow dr in dgvReturnRequests.Rows)
            {
                string s = dr.Cells[1].Value.ToString();
                DataTable pn = new DataTable();
                tp.populatedt("Select p.pname,o.OrderId from Product p JOIN OrderItem o on p.Id=o.ProductId where o.Id='" + Convert.ToInt32(s) + "'", pn);
                foreach (DataRow dr1 in pn.Rows)
                {
                    dr.Cells[1].Value = dr1["pname"].ToString();
                    dr.Cells[4].Value = dr1["OrderId"].ToString(); //here I am adding the value in newly added column
    
                }
            }
               dgvReturnRequests.DataSource=dr;
               dgvReturnRequests.DataBind();
