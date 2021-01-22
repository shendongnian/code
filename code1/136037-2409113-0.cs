    Application oxl = null;
			try
			{
				oxl = new Application( );
				oxl.Visible = true;
				oxl.DisplayAlerts = false;
				string fileName = @"D:\one.xls";
				object missing = Missing.Value;
				Workbook wbook = oxl.Workbooks.Open( fileName, missing, missing, missing, missing, missing,missing,missing,missing,missing,missing,missing,missing,missing,missing );
				Worksheet wsheet = ( Worksheet )wbook.ActiveSheet;
				wsheet.Name = "Customers";
				System.Data.DataTable dt = new System.Data.DataTable( "test" );
				dt.Columns.Add( "col1" );
				dt.Columns.Add( "col2" );
				dt.Columns.Add( "col3" );
				dt.Rows.Add( new object[ ] { "one", "one", "one" } );
				dt.Rows.Add( new object[ ] { "two", "two", "two" } );
				dt.Rows.Add( new object[ ] { "three", "three", "three" } );
				for ( int i = 1 ; i <=  dt.Columns.Count ; i++ )
				{
					wsheet.Cells[ 1, i ] = dt.Columns[ i - 1 ].ColumnName;
				}
				for ( int j = 1 ; j <= dt.Rows.Count ; j++ )
				{
					for ( int k = 0 ; k <  dt.Columns.Count ; k++ )
					{
						DataRow dr = dt.Rows[ k ];
						wsheet.Cells[ j +1, k+1 ] = dr[ k ].ToString( );
					}
				}
				Range range = wsheet.get_Range( wsheet.Cells[ 1, 1 ],
							  wsheet.Cells[ dt.Rows.Count + 1, dt.Columns.Count ] );//In this place i got the exception
				range.EntireColumn.AutoFit( );
				wbook.Save( );
				wsheet = null;
				range = null;
				
			}
			finally
			{
				oxl.Quit( );
				System.Runtime.InteropServices.Marshal.ReleaseComObject( oxl );
				oxl = null;
			}
