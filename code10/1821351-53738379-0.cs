			var outlookApplication = new Application();
			NameSpace mapiNamespace = outlookApplication.GetNamespace("MAPI");
			MAPIFolder calendar = mapiNamespace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
			if (calendar != null)
			{
				for (int i = 1; i < calendar.Items.Count + 1; i++)
				{
					var calendarItem = (AppointmentItem)calendar.Items[i];
				}
			}
