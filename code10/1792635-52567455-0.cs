    string query1 = "SELECT * FROM attendance WHERE Date between @startDate AND @endDate and Student_ID = @studentId";
    SqlCommand sqlcomm = new SqlCommand(query1, con);
    sqlcomm.Parameters.Add("@startDate", SqlDbType.Date).Value = datepicker.Text;
    sqlcomm.Parameters.Add("@endDate", SqlDbType.Date).Value = datepicker1.Text;
    sqlcomm.Parameters.Add("@studentId", SqlDbType.Int).Value = 100;
