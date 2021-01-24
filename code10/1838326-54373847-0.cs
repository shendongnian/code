    DataTable apptDetails = (from t1 in customer.AsEnumerable()
    join t2 in appointments.AsEnumerable() on Convert.ToInt32(t1["customerId"]) equals Convert.ToInt32(t2["customerId"])
    into tableGroup
     select new
       {
        customerId = t1["customerId"],
        TotalAppointments = tableGroup.Count(),
        appointment_missed = Convert.ToInt32(t1["MissedAppt"]),
        appointment_show_rate = (
                                    tableGroup.Count()>0 ? 
                                        Math.Round((1 - ((double)Convert.ToInt32(t1["MissedAppt"]) / (double)tableGroup.Count())),2)
                                        : 0
                                )
        }).CopyToDataTable();
