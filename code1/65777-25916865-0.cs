    Me._commandCollection = New Global.System.Data.SqlClient.SqlCommand(5) {}
    
    Me._commandCollection(0) = New Global.System.Data.SqlClient.SqlCommand()
    
    Me._commandCollection(0).Connection = Me.Connection
    
    Me._commandCollection(0).CommandTimeout = 60
    
    Me._commandCollection(0).CommandText = "SELECT MK_QR_SUB_AND_DETAIL.*" & _ "Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)" & _ "FROM MK_QR_SUB_AND_DETAIL"
    
    Me._commandCollection(0).CommandType = Global.System.Data.CommandType.Text    
    
    Me._commandCollection(1) = New Global.System.Data.SqlClient.SqlCommand()
    
    Me._commandCollection(1).Connection = Me.Connection
    
    Me._commandCollection(1).CommandTimeout = 60
    
    Me._commandCollection(1).CommandText = "dbo.spQtrRptTesting_RunInserts_Step1of4"
    
    Me._commandCollection(1).CommandType = Global.System.Data.CommandType.StoredProcedure
    
    Me._commandCollection(1).Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@RETURN_VALUE", Global.System.Data.SqlDbType.Int, 4, Global.System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
    
    Me._commandCollection(1).Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@pStartADate", Global.System.Data.SqlDbType.[Date], 3, Global.System.Data.ParameterDirection.Input, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
    
    Me._commandCollection(1).Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@pEndADate", Global.System.Data.SqlDbType.[Date], 3, Global.System.Data.ParameterDirection.Input, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
    
    Me._commandCollection(1).Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@pStartBDate", Global.System.Data.SqlDbType.[Date], 3, Global.System.Data.ParameterDirection.Input, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
    
    Me._commandCollection(1).Parameters.Add(New Global.System.Data.SqlClient.SqlParameter("@pEndBDate", Global.System.Data.SqlDbType.[Date], 3, Global.System.Data.ParameterDirection.Input, 10, 0, Nothing, Global.System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
