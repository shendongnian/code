    public static List<AttendenceManual> PreocessData(DataSet data)
            {
                List<AttendenceManual> _AttendenceManualList = new List<AttendenceManual>();
    
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    AttendenceManual Student = new AttendenceManual();
                    Student.StrEmpID = data.Tables[0].Rows[i]["F2"].ToString();
                    _AttendenceManualList.Add(Student);
                }
    
                return _AttendenceManualList;
            }
