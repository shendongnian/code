      SqlConnection con1 = new SqlConnection(conString);
            con1.Open();
            string q1 = "select * from Customer_Transaction where Cust_No ='C0001'";
            SqlCommand cmd = new SqlCommand(q1, con1);
            cmd.ExecuteNonQuery(); ;
            //ResultDataGrid.Rows.Add("TOTALS", q2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable_customer_transaction_result);
            var totalSum = 0.0M;
            foreach (var row in dataTable_customer_transaction_result.Tables[0].Rows)
            {
                totalSum += Convert.ToDecimal(row["Bill_Amount"]);
            }
