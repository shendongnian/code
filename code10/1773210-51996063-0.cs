	var dtReservation = new DataTable();
	dtReservation.Columns.Add("Sr. No.", typeof(Int32));
	dtReservation.Columns.Add("ArrvDate", typeof(DateTime));
	dtReservation.Columns.Add("Departure", typeof(DateTime));
	dtReservation.Rows.Add(new Object[] { 1, new DateTime(2018, 8, 10), new DateTime(2018, 8, 11) });
	dtReservation.Rows.Add(new Object[] { 2, new DateTime(2018, 8, 11), new DateTime(2018, 8, 12) });
	dtReservation.Rows.Add(new Object[] { 3, new DateTime(2018, 8, 12), new DateTime(2018, 8, 13) });
	dtReservation.Rows.Add(new Object[] { 4, new DateTime(2018, 8, 13), new DateTime(2018, 8, 14) });
	var dtCurrnet = DateTime.Now.Date.AddDays(-11);
	EnumerableRowCollection<DataRow> query =
        from arrvDate in dtReservation.AsEnumerable()
	    where arrvDate.Field<DateTime>("ArrvDate") > dtCurrnet
	    select arrvDate;
