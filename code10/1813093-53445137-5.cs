    var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Delete"].ConnectionString);           
        con.Open();
        var cmd = new SqlCommand("Delete from " + dbTable  +
                                        " where " + dbTable + ".agencyid = " + agency.id, con);
        cmd.ExecuteNonQuery();
        con.Close();
