    using System;
    using System.Data;
    using System.Data.OleDb;
    
    namespace ExportExcelToAccess
    {
    	/// <summary>
    	/// Summary description for ExcelHelper.
    	/// </summary>
    	public sealed class ExcelHelper
    	{
    		private const string CONNECTION_STRING = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=<FILENAME>;Extended Properties=\"Excel 8.0;HDR=Yes;\";";
    
    		public static DataTable GetDataTableFromExcelFile(string fullFileName, ref string sheetName)
    		{
    			OleDbConnection objConnection = new OleDbConnection();
    			objConnection = new OleDbConnection(CONNECTION_STRING.Replace("<FILENAME>", fullFileName));
    			DataSet dsImport = new DataSet();
    
    			try
    			{
    				objConnection.Open();
    			
    				DataTable dtSchema = objConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    
    				if( (null == dtSchema) || ( dtSchema.Rows.Count <= 0 ) )
    				{
    					//raise exception if needed
    				}
    				
    				if( (null != sheetName) && (0 != sheetName.Length))
    				{
    					if( !CheckIfSheetNameExists(sheetName, dtSchema) )
    					{
    						//raise exception if needed
    					}
    				}
    				else
    				{
    					//Reading the first sheet name from the Excel file.
    					sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
    				}
    				
    				new OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", objConnection ).Fill(dsImport);
    			}
    			catch (Exception)
    			{
    				//raise exception if needed
    			}
    			finally
    			{
    				// Clean up.
    				if(objConnection != null)
    				{
    					objConnection.Close();
    					objConnection.Dispose();
    				}
    			}
    
    			
    			return dsImport.Tables[0];
    			#region Commented code for importing data from CSV file.
    			//				string strConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +"Data Source=" + System.IO.Path.GetDirectoryName(fullFileName) +";" +"Extended Properties=\"Text;HDR=YES;FMT=Delimited\"";
    			//
    			//				System.Data.OleDb.OleDbConnection conText = new System.Data.OleDb.OleDbConnection(strConnectionString);
    			//				new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(fullFileName).Replace(".", "#"), conText).Fill(dsImport);
    			//				return dsImport.Tables[0];
    
    			#endregion
    		}
    
    		/// <summary>
    		/// This method checks if the user entered sheetName exists in the Schema Table
    		/// </summary>
    		/// <param name="sheetName">Sheet name to be verified</param>
    		/// <param name="dtSchema">schema table </param>
    		private static bool CheckIfSheetNameExists(string sheetName, DataTable dtSchema)
    		{
    			foreach(DataRow dataRow in dtSchema.Rows)
    			{
    				if( sheetName == dataRow["TABLE_NAME"].ToString() )
    				{
    					return true;
    				}	
    			}
    			return false;
    		}
    	}
    }
