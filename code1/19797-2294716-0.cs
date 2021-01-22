	using System.Data;
	using System.Data.Sql
	using System.Data.SqlClient;
	using System.Web;
	using System.Web.Services;
	public class FileUploader: System.Web.Services.WebService {
		 SqlConnection myConnection = new SqlConnection("Data Source=server name ;Initial Catalog=database name; User ID=username; Password='password';");
		 SqlCommand myCommand = new SqlCommand();
		 string queryString = "";
	public string UploadFile(byte[] f, string fileName)
	  {
				 // the byte array argument contains the content of the file
				// the string argument contains the name and extension
			   // of the file passed in the byte array
	string nm = data[0];
	string sn =data[1];
	string bn =data[2];
	string st = data[3];
	byte img = Convert.Tobyte(img);
	myConnection.Open();
	queryString = "INSERT INTO tablename(Name,SchemeName,BeneficiarName,Status,Photo)"
	+ "VALUES('" + nm + "','" + sn + "','"+ bn +"','" + st + "',@img,')";
	myCommand.Parameters.AddWithValue("@img",f);
	myCommand.Connection = myConnection;
	myCommand.CommandType = CommandType.Text; myCommand.CommandText = queryString; int res = myCommand.ExecuteNonQuery(); myConnection.Close();
	if (res > 0)
	{
	   strres = "File Uploaded successfully"; }
	else
	{ 
	   strres = "File not uploaded";
	}
	 return strres;
	}
  
