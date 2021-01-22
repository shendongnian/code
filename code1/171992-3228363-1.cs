	object app = folder.Items.GetFirst();
	while (app != null)
	{
		if (app is AppointmentItem && ((AppointmentItem)app).Start.Date == DateTime.Now.Date)
		{
			this.Appointments.Add(((AppointmentItem)app));
		}
		app = folder.Items.GetNext();
	}
