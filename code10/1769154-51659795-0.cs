	// Set the request properties.
	bulkDeleteRequest.JobName = "Backup Bulk Delete";
	// Querying activities
	bulkDeleteRequest.QuerySet = new QueryExpression[]
	{
		opportunitiesQuery,
		BuildActivityQuery(Task.EntityLogicalName),
		BuildActivityQuery(Fax.EntityLogicalName),
		BuildActivityQuery(PhoneCall.EntityLogicalName),
		BuildActivityQuery(Email.EntityLogicalName),
		BuildActivityQuery(Letter.EntityLogicalName),
		BuildActivityQuery(Appointment.EntityLogicalName),
		BuildActivityQuery(ServiceAppointment.EntityLogicalName),
		BuildActivityQuery(CampaignResponse.EntityLogicalName),
		BuildActivityQuery(RecurringAppointmentMaster.EntityLogicalName)
	};
	// Set the start time for the bulk delete.
	bulkDeleteRequest.StartDateTime = DateTime.Now;
	// Set the required recurrence pattern.
	bulkDeleteRequest.RecurrencePattern = String.Empty;
	// Set email activity properties.
	bulkDeleteRequest.SendEmailNotification = false;
	bulkDeleteRequest.ToRecipients = new Guid[] { currentUserId };
	bulkDeleteRequest.CCRecipients = new Guid[] { };
	// Submit the bulk delete job.
	// NOTE: Because this is an asynchronous operation, the response will be immediate.
	_bulkDeleteResponse =
		(BulkDeleteResponse)_serviceProxy.Execute(bulkDeleteRequest);
	Console.WriteLine("The bulk delete operation has been requested.");
