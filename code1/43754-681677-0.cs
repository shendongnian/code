protected void GetColumNames_DataReader()
{
  System.Data.SqlClient.SqlConnection SqlCon = new System.Data.SqlClient.SqlConnection( "server=localhost;database=northwind;trusted_connection=true" );
  System.Data.SqlClient.SqlCommand SqlCmd = new System.Data.SqlClient.SqlCommand( "SELECT * FROM Products", SqlCon );
  SqlCon.Open();
  System.Data.SqlClient.SqlDataReader SqlReader = SqlCmd.ExecuteReader();
  System.Int32 _columncount = SqlReader.FieldCount;
  System.Web.HttpContext.Current.Response.Write( "SqlDataReader Columns" );
  System.Web.HttpContext.Current.Response.Write( " " );
  for ( System.Int32 iCol = 0; iCol < _columncount; iCol ++ )
  {
    System.Web.HttpContext.Current.Response.Write( "Column " + iCol.ToString() + ": " );
    System.Web.HttpContext.Current.Response.Write( SqlReader.GetName( iCol ).ToString() );
    System.Web.HttpContext.Current.Response.Write( " " );
  }
}
