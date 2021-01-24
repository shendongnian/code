	var dueDateString = "08-11-2018";
	var paymentDateString = "18-11-2018";
	
	DateTime dueDate;
	DateTime paymentDate;
	
	DateTime.TryParseExact(
        dueDateString,
        "dd-MM-yyyy",
        System.Globalization.CultureInfo.InvariantCulture, 
        System.Globalization.DateTimeStyles.AdjustToUniversal,
        out dueDate);
	DateTime.TryParseExact(
        paymentDateString,
        "dd-MM-yyyy",
        System.Globalization.CultureInfo.InvariantCulture, 
        System.Globalization.DateTimeStyles.AdjustToUniversal,
        out paymentDate);
	
	if (paymentDate != default(DateTime)) // valid payment date
		dataGridView1.Rows[i].Cells["Status"].Value = "Paid";
	else if (dueDate > DateTime.Today) // due date is in the future
		dataGridView1.Rows[i].Cells["Status"].Value = "Up Coming";
	else // payment is overdue
		dataGridView1.Rows[i].Cells["Status"].Value = "Pending";
