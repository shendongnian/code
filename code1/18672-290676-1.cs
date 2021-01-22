    using System; 
    using System.Data; 
    using System.Data.SqlClient; 
    
	class OutputParams 
	{ 
		[STAThread] 
		static void Main(string[] args) 
		{ 
		using( SqlConnection cn = new SqlConnection("server=(local);Database=Northwind;user id=sa;password=;")) 
		{ 
			SqlCommand cmd = new SqlCommand("CustOrderOne", cn); 
			cmd.CommandType=CommandType.StoredProcedure ; 
			
			SqlParameter parm= new SqlParameter("@CustomerID",SqlDbType.NChar) ; 
			parm.Value="ALFKI"; 
			parm.Direction =ParameterDirection.Input ; 
			cmd.Parameters.Add(parm); 
			
			SqlParameter parm2= new SqlParameter("@ProductName",SqlDbType.VarChar); 
			parm2.Size=50; 
			parm2.Direction=ParameterDirection.Output; 
			cmd.Parameters.Add(parm2); 
			
			SqlParameter parm3=new SqlParameter("@Quantity",SqlDbType.Int); 
			parm3.Direction=ParameterDirection.Output; 
			cmd.Parameters.Add(parm3);
			
			cn.Open(); 
			cmd.ExecuteNonQuery(); 
			cn.Close(); 
			
			Console.WriteLine(cmd.Parameters["@ProductName"].Value); 
			Console.WriteLine(cmd.Parameters["@Quantity"].Value.ToString());
			Console.ReadLine(); 
		} 
	} 
