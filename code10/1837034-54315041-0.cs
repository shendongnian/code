        public int? GetPatientNumber(int Patient_No)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable dt = new DataTable();
            SqlParameter[] Param = new SqlParameter[1];
            Param[0] = new SqlParameter("@Patient_No", SqlDbType.Int);
            Param[0].Value = Patient_No;
            dt = DAL.SelectData("VALIDATE_PATIENT_EXIST", Param);
            DAL.close();
            
            int? patientNumber = dt.Field<int>(0, "Patient_No");
            return patientNumber;
        }
