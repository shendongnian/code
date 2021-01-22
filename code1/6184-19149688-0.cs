	//using Microsoft.Office.Interop.Outlook
	Application a = new Application();
	Items i = a.Session.GetDefaultFolder(OlDefaultFolders.olFolderCalendar).Items;
	i.IncludeRecurrences = true;
	i.Sort("[Start]");
	i = i.Restrict(
		"[Start] >= '10/1/2013 12:00 AM' AND [End] < '10/3/2013 12:00 AM'");
 
	var r =
		from ai in i.Cast<AppointmentItem>()
		select new {
			ai.Categories,
			ai.Start,
			ai.Duration
			};
	r.Dump();
