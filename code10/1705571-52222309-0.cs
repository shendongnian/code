        Dim _DataReader As SqlDataReader = Nothing
        Dim SQLCon As New SqlClient.SqlConnection("Your connection string")
        SQLCon.Open()
        Dim SQLCom = New SqlCommand
        With SQLCom
            .Connection = SQLCon
            .CommandText = "SP_INS_ResponseTable"
            .CommandType = CommandType.StoredProcedure
            Dim _Param1 As New SqlParameter("@SystemName", SqlDbType.Varchar)
            Dim _Param2 As New SqlParameter("@ClientName", SqlDbType.Varchar)
			Dim _Param3 As New SqlParameter("@TableValueTypeII", SqlDbType.Structured)
			Dim _Param4 As New SqlParameter(PARAM_OUT_SQLMSG, SqlDbType.Int32)			
			
			//pass the parameters values here 
            _Param1.Value = _SystemName
            _Param2.Value = _ClientName
			_Param3.Value = _TableValueTypeII
			_Param4.Value = _PARAM_OUT_SQLMSG
            .Parameters.Add(_Param1)
            .Parameters.Add(_Param2).
			.Parameters.Add(_Param3)
			.Parameters.Add(_Param4)	
        End With
        _DataReader = SQLCom.ExecuteReader()
        While (_DataReader.Read)
            Dim _Record As New (your own returned data type)
            With _Record 
                .SystemName = (_DataReader(0)) // make sure they are not null(_DataReader(x)) assign it to empty string if so
                .ClientName = (_DataReader(1))
                .TableValueTypeII = (_DataReader(2))
                .PARAM_OUT_SQLMSG = (_DataReader(3))
            End With
            return _Record
        End While
        SQLCon.Close()
        SQLCon.Dispose()
        SQLCom.Dispose()
