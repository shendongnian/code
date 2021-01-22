            string query = "SELECT * FROM Categories; SELECT * FROM Products";
            SqlConnection con = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataSet ds = new DataSet();
            da.Fill(ds, "CategoriesAndProducts");     //CategoriesAndProducts dataset
            string s = ds.Tables[0].Rows[0]["Name"].ToString();  
            string s1 = ds.Tables[1].Rows[0]["Name"].ToString(); 
            Console.WriteLine(s);  //from categories [0][0] like Electronic
            Console.WriteLine(s1); //from Products  [0][0]  like LG
