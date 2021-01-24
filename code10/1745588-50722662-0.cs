    Oracle.DataAccess.Client.OracleParameter tcParam = new Oracle.DataAccess.Client.OracleParameter();
            tcParam.ParameterName = "P_CODE";
            tcParam.OracleDbType = Oracle.DataAccess.Client.OracleDbType.Varchar2;
            tcParam.Size = 10;
            tcParam.Direction = ParameterDirection.Output;
            oraComm.Parameters.Add(tcParam);
