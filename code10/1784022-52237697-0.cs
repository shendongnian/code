		@Html.CheckBox("cb_Notify", Model.EmployeeNotification[i].Notify, new { type = "hidden" })
		@*Do not allow editing of the Notify field for employees who have been sent the notification already*@
		@if (Model.EmployeeNotification[i].NotifiedOn >= DateTime.Parse("2000-01-01 12:00:00 AM"))
		{
			@Html.DisplayFor(modelItem => Model.EmployeeNotification[i].Notify)
		}
		else
		{
			@*Hidden items for the post back information*@
			@Html.HiddenFor(modelItem => Model.EmployeeNotification[i].NotificationID)
			@Html.HiddenFor(modelItem => Model.EmployeeNotification[i].EmployeeID)
			@Html.CheckBoxFor(modelItem => Model.EmployeeNotification[i].Notify, new { @class = "notify" })
		}
