      List<mydata> filteredData = new List<mydata>();
      ///As OP commented,the date/time look like :  Saturday, April 14, 2018
      string m0nth = "August" 
      //Or      
      string month = DateTime.Now.Month.ToString()
      cmd = new SqlCommand("Select * from Daily_Sale ", con);
      SqlDataReader dr = cmd.ExecuteReader()
      While (dr.Reader())
       {
        string mnth = dr[2].ToString().Split(', ',', ')[0];  ///change 2 with the column count of the date column
        string finalMonth = mnth.Split(" ")[0];
        if (finalMonth == month)
        {
         mydata dt = new mydata();
         dt.name = dr[0].ToString();
         //keep continuing for each column/each variable in the class we created
        filteredData.Add(dt);
      }}}
