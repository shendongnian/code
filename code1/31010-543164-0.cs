			WriteIf ( "===================================================" + msg + " START " );
			if (ds != null)
			{
				WriteIf ( msg );
				foreach (System.Data.DataTable dt in ds.Tables)
				{
					WriteIf ( "================= My TableName is  " +
					dt.TableName + " ========================= START" );
					int colNumberInRow = 0;
					foreach (System.Data.DataColumn dc in dt.Columns)
					{
						System.Diagnostics.Debug.Write ( " | " );
						System.Diagnostics.Debug.Write ( " |" + colNumberInRow + "| " );
						System.Diagnostics.Debug.Write ( dc.ColumnName + " | " );
						colNumberInRow++;
					} //eof foreach (DataColumn dc in dt.Columns)
					int rowNum = 0;
					foreach (System.Data.DataRow dr in dt.Rows)
					{
						System.Diagnostics.Debug.Write ( "\n row " + rowNum + " --- " );
						int colNumber = 0;
						foreach (System.Data.DataColumn dc in dt.Columns)
						{
							System.Diagnostics.Debug.Write ( " |" + colNumber + "| " );
							System.Diagnostics.Debug.Write ( dr[dc].ToString () + " " );
							colNumber++;
						} //eof foreach (DataColumn dc in dt.Columns)
						rowNum++;
					}	//eof foreach (DataRow dr in dt.Rows)
					System.Diagnostics.Debug.Write ( " \n" );
					WriteIf ( "================= Table " +
	dt.TableName + " ========================= END" );
					WriteIf ( "===================================================" + msg + " END " );
				}	//eof foreach (DataTable dt in ds.Tables)
			} //eof if ds !=null 
			else
			{
				WriteIf ( "NULL DataSet object passed for debugging !!!" );
			}
		} //eof method 
