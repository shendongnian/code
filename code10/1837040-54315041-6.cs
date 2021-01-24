        public int? GetPatientNumber(int Patient_No)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@Patient_No", SqlDbType.Int);
            Param[0].Value = Patient_No;
            dt = DAL.SelectData("VALIDATE_PATIENT_EXIST", Param);
            DAL.close();
             
            // if there is at least one row
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                int? patientNumber = row.Field<int>("Patient_No");
                return patientNumber;
            }
            // return null otherwise
            return null;
        }
