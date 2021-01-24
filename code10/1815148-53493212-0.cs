    Try
        Dim CONN = New MySql.Data.MySqlClient.MySqlConnection("server=localhost;user=<user>;database=<database>;port=3306;password=<password>;allowbatch=true;allowuservariables=true;")
        Dim CMDTXT =
            <sql>
                DROP procedure IF EXISTS `sample`; 
                CREATE PROCEDURE `sample`( 
                    in_varA int(11),
                    in_varB int(11),
                    in_varC int(11)
                )
                BEGIN
                    SET @query = CONCAT("SELECT ",in_varA + in_varB + in_varC);
	    
                    PREPARE Statement FROM @Query;
                    EXECUTE Statement;
                    DEALLOCATE PREPARE Statement;                        
                END;
            </sql>
                CONN.Open()
        Using TRAN = CONN.BeginTransaction
        Using CMD = CONN.CreateCommand
                CMD.CommandText = CMDTXT.Value
                CMD.CommandType = CommandType.Text
                CMD.ExecuteNonQuery()
                TRAN.Commit()
            End Using
    End Using
        CONN.Close()
    Catch ex As Exception
        MsgBox(ex.Message)
        Exit Sub
    End Try
    MsgBox("success")
