    public string getCopay(string PatientID)
    {
           string sqlStr = "select ISNULL(Copay,'') Copay from Test where patient_id=" + PatientID ;
            string strCopay = (string)SqlHelper.ExecuteScalar(CommonCS.ConnectionString, CommandType.Text, sqlStr);
                    if (String.IsNullOrEmpty(strCopay))
                        return "";
                    else
                        return strCopay ;
    }
