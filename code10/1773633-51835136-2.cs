            string query = string.Format(
                                        @"UPDATE CardStatus
                                          SET DateExpired = @dateExpired,
                                              ModifiedBy = @modifiedBy,
                                              ModifiedOn = @modifiedOn
                                          WHERE
                                            IDNo = @idNo");
            List<OracleParameter> parameters = new List<OracleParameter>();
            OracleParameter pIdNo = new OracleParameter("idNo", OracleDbType.Varchar2);
            pIdNo.Value = idNo;
            OracleParameter pDateExpired = new OracleParameter("dateExpired", OracleDbType.Date);
            pDateExpired.Value = dateExpired;
            OracleParameter pModifiedBy = new OracleParameter("modifiedBy", OracleDbType.Varchar2);
            pModifiedBy.Value = "SIS";
            OracleParameter pModifiedOn = new OracleParameter("modifiedOn", OracleDbType.Date);
            pModifiedOn.Value = DateTime.Now;
            parameters.Add(pIdNo);
            parameters.Add(pDateExpired);
            parameters.Add(pModifiedBy);
            parameters.Add(pModifiedOn);
            bool result = _DAL.ExecuteNonQuery(query, parameters.ToArray());
