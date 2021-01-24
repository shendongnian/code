    using (SqlConnection conn = new SqlConnection(""))
    {
       conn.Open();
       int result = 0;
    
       if (int.TryParse(txtJusM.Text, out result) && result > 0)
       {
          using (SqlCommand cmd13 = new SqlCommand("INSERT INTO Transaksi (idStruk,Product_Name,Jumlah,TotalHarga,Tanggal_Transaksi) VALUES (@idStruk,@Product_Name,@Jumlah,@TotalHarga,@Tanggal_Transaksi)", con))
          {
             ...
          }
       }
    
       if (int.TryParse(txtJusA.Text, out result) && result > 0)
       {
          using (SqlCommand cmd14 = new SqlCommand("INSERT INTO Transaksi (idStruk,Product_Name,Jumlah,TotalHarga,Tanggal_Transaksi) VALUES (@idStruk,@Product_Name,@Jumlah,@TotalHarga,@Tanggal_Transaksi)", con))
          {
             ...
          }
       }
    
       if (int.TryParse(txtJusJ.Text, out result) && result > 0)
       {
          using (var cmd15 = new SqlCommand("INSERT INTO Transaksi (idStruk,Product_Name,Jumlah,TotalHarga,Tanggal_Transaksi) VALUES (@idStruk,@Product_Name,@Jumlah,@TotalHarga,@Tanggal_Transaksi)", con))
          {
             ...
          }
       }
    
       if (int.TryParse(txtJusS.Text, out result) && result > 0)
       {
          using (var cmd16 = new SqlCommand("INSERT INTO Transaksi (idStruk,Product_Name,Jumlah,TotalHarga,Tanggal_Transaksi) VALUES (@idStruk,@Product_Name,@Jumlah,@TotalHarga,@Tanggal_Transaksi)", con))
          {
             ...
          }
       }
    
       conn.Close();
    }
