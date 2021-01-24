	public class ExcelDAL
	{
		private string sExcelFile = string.Empty;
		private string sExcelSheet = string.Empty;
		private bool bUseHeaders = false;
		private bool bUseIMEX = false;
		
		public ExcelDAL(string _ExcelFile, string _ExcelSheet, bool _UseHeaders, bool _UseIMEX)
		{
			sExcelFile = _ExcelFile;
			sExcelSheet = _ExcelSheet;
			bUseHeaders = _UseHeaders;
		}
		
			
		private string GetConnString()
		{
			string suh = bUseHeaders ? "YES" : "NO";
			string sui = bUseIMEX ? "IMEX=1;" : "";
			return string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR={1}';{2}", sExcelFile, suh, sui);
		}
		
		public DataTable GetSheetData()
		{
			DataTable dt = new DataTable();
			using (OleDbConnection connection = new OleDbConnection(GetConnString()))
			{
				string sql = string.Format(@"SELECT * FROM [{0}$];", sExcelSheet);
				connection.Open();
				using(OleDbCommand command = new OleDbCommand(sql, connection))
				{
					using (OleDbDataReader reader = command.ExecuteReader())
					{
						dt.Load(reader);
					}
				}
			}
			return dt;
		}
		
		//other members and methods of DAL class
	}
