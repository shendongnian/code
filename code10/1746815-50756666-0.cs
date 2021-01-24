      clConnection clConn = new clConnection();
                SqlConnection conn = clConn.openConnection();
        
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
    comm.CommandText = "UPDATE userTBL SET SifraPrimac=SifraPrimac+1, SifraIsplakac=SifraIsplakac+1";
        comm.ExecuteNonQuery();
