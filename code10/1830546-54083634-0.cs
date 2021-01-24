	// using System.Data.SqlClient;
	const string srcConnString = "data source=DESKTOP-Q8526KR;initial catalog=dentned;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
	var csBuilder = new SqlConnectionStringBuilder(srcConnString);
	csBuilder.Remove("Integrated Security");
	csBuilder.UserID = "somesqluser";
	csBuilder.Password = "password";
	var connString = csBuilder.ToString();
	
	SqlConnection sqlcon = new SqlConnection(connString);
