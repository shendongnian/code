    // Include RollNo in getAttendance list
    var getAttendance = (from r in db.RollNoSlips
                         from a in db.Attendances
                         where r.RollNo == a.RollNo
                         select new {a.AttendanceStatus, a.RollNo}
    ).ToList();
    ...
    // Updates getAttendance rows in the database, one row at a time
    using (var cmd = new SqlCommand("update RollNoSlip set AttendanceStatus=@Attendance where RollNo=@RollNo", con))
    {
        cmd.Parameters.Add("@Attendance", SqlDbType.VarChar);
        cmd.Parameters.Add("@Attendance", SqlDbType.Int);
        for (int i = 0; i < getAttendance.Count; i++)
        {
            cmd.Parameters["@Attendance"].Value = getAttendance[i].AttendanceStatus;
            cmd.Parameters["@RollNo"].Value = getAttendance[i].RollNo;
            cmd.ExecuteNonQuery();                                                                           
        }
    }
