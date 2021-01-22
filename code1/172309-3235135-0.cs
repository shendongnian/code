    public static class PerstistendDB
    	{
    		// Readonly so it can't be destroyed!
    		public static readonly System.Data.SqlClient.SqlConnection pripojeni = new System.Data.SqlClient.SqlConnection(
    			"Data Source=localhost\\SQLEXPRESS;Initial Catalog=XYZ;Trusted_Connection=True;Min Pool Size=20");
    	}
