            var conn = new SqlConnection("connection string");
            conn.Open();
            SqlCommand comm = new SqlCommand("Update item set qty = '" + 30 + "'where itemId ='" + 1 + "'",conn);
            comm.ExecuteNonQuery();
            DateTime d = DateTime.Now;
            int day = d.Day;
            int month = d.Month;
            int year = d.Year;
            string dt = year + "/" + month + "/" + day;
            string username = "jyothi";
            SqlCommand query2 = new SqlCommand("Insert into sale (empID,date1) values ('" + 22 + "','" + dt + "')",conn);
            query2.ExecuteNonQuery();
            int saleid=0;
            SqlCommand query3 = new SqlCommand("select top 1 id from sale order by id desc",conn);
            var dreader = query3.ExecuteReader();
            if (dreader.Read())
            {
                saleid = Convert.ToInt32(dreader[0].ToString());
            }
            dreader.Close();
        
            SqlCommand query4 = new SqlCommand("Insert into saleitem (saleid,itemId, qty, price) values ('" + saleid + "','" + 1 + "','" + 20 + "','" + 25 + "')", conn);
            query4.ExecuteNonQuery();
