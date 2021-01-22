    Dim db As Database = DatabaseFactory.CreateDatabase(ApplicationStringResource.DbConn)
        Dim cmd As DbCommand = db.GetStoredProcCommand(DbStoreProc.GetFeeCodeStoreProc)
        Dim sReader As SqlDataReader = db.ExecuteReader(cmd)
        Try
            While sReader.Read()
                Dim feeCode As New FeeCode()
                With feeCode
                    .FeeCode = sReader("FeeCode")
                    .Description = sReader("Description")
                End With
                feeCodeList.Add(feeCode)
            End While
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            sReader.Close()
        End Try
        Return feeCodeList
