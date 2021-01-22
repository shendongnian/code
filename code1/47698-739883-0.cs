	using System;
	using System.Data;
	using System.Collections;
	using System.Reflection;
	namespace GenApp.Utils.Data
	{
	/// <summary>
	/// Summary description for ObjectConverter
	/// </summary>
	public class ObjectConverter
	{
		
		private DataTable ConvertIEnumerableToDataTable ( IEnumerable dataSource )
		{
			System.Reflection.PropertyInfo[] propInfo = null;
			DataTable dt = new DataTable ();
			foreach (object o in dataSource)
			{
				propInfo = o.GetType ().GetProperties ();
				for (int i = 0; i < propInfo.Length; i++)
				{
					dt.Columns.Add ( propInfo[i].Name );
				}
				break;
			}
			foreach (object tempObject in dataSource)
			{
				DataRow dr = dt.NewRow ();
				for (int i = 0; i < propInfo.Length; i++)
				{
					object t = tempObject.GetType ().InvokeMember ( propInfo[i].Name, BindingFlags.GetProperty, null, tempObject, new object[] { } );
					if (t != null)
						dr[i] = t.ToString ();
				}
				dt.Rows.Add ( dr );
			}
			return dt;
		} //eof method 
		public static string DataTableToString ( ref DataTable dt, bool flagDebugRows )
		{
			if (dt == null)
				return String.Empty;
			//string strData = dt.TableName + "\r\n";
			string strData = String.Empty;
			string sep = string.Empty;
			if (dt.Rows.Count > 0)
			{
				int colCount = 0;
				if (flagDebugRows)
				{
					foreach (DataColumn c in dt.Columns)
					{
						if (c.DataType != typeof ( System.Guid ) &&
						c.DataType != typeof ( System.Byte[] ))
						{
							strData += " | " + colCount.ToString () + " | ";
							strData += sep + c.ColumnName;
							sep = "\t";
							colCount++;
						}
					}
					strData += "\r\n";
				}
				int rowCount = 0;
				foreach (DataRow r in dt.Rows)
				{
					sep = string.Empty;
					colCount = 0;
					strData += " | " + rowCount.ToString () + " | ";
					foreach (DataColumn c in dt.Columns)
					{
						if (flagDebugRows)
							strData += " | " + colCount.ToString () + " | ";
						if (c.DataType != typeof ( System.Guid ) &&
						c.DataType != typeof ( System.Byte[] ))
						{
							if (!Convert.IsDBNull ( r[c.ColumnName] ))
								strData += sep +
								r[c.ColumnName].ToString ();
							else
								strData += sep + "";
							sep = "\t";
						}
						colCount++;
					}
					strData += "\r\n";
					rowCount++;
				}
			}
			else
				strData += "\r\n---> Table was empty!";
			return strData;
		} //eof method 
		public static void DsToString ( ref GenApp.Bo.User userObj, ref System.Data.DataSet ds, out string strDsAsStr )
		{
			strDsAsStr = String.Empty;
			if (ds == null)
			{
				userObj.Rc.Msg = "No results found !!!";
				userObj.Rc.DebugMsg = " Empty ds passed for debugging at DsToString method , DataSetGastArbeiter class ";
			} //eof if
			else
			{
				//foreach (System.Data.DataTable dt in ds.Tables)
				for (int i = 0; i < ds.Tables.Count; i++)
				{
					DataTable dt = ds.Tables[i];
					strDsAsStr += DataTableToString ( ref dt, true );
				}	//eof foreach (DataTable dt in ds.Tables)
			} //eof if ds !=null 
		} //eof method 
		#region Todo
		//not in use YET 
		public static bool FromDataSetToObjectPool ( ref GenApp.Bo.User userObj, ref DataSet ds, ref Data.ObjectConverter pool )
		{
			return true;
		}
		#endregion Todo
	} //eof class 
	} //eof namespace GenApp.
