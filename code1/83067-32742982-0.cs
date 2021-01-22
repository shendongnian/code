    ////BEGIN OUTLOOK DECLARATIONS
        public static dynamic objOutlook = Activator.CreateInstance(Type.GetTypeFromProgID("Outlook.Application"));
        public static int appointmentItem = 1;
        public static int mailItem = 0;
        public static int inboxItem = 6;
        public static dynamic mapiNamespace = objOutlook.GetNamespace("MAPI");
        public static dynamic inboxFolder = mapiNamespace.GetDefaultFolder(inboxItem);
        public static dynamic mailObject = objOutlook.CreateItem(mailItem);
        public static dynamic appointmentObject = objOutlook.CreateItem(appointmentItem);
        public static string defaultEmail = mapiNamespace.DefaultStore.DisplayName; //mapiNamespace.CurrentUser.DefaultStore.DisplayName;
        ////END OUTLOOK DECLARATIONS
    public static string CreateAppointmentOutlookDirect(char StatusType, int ID, string EventID, string EventIDRef, string Subject, string Description, string Location, DateTime EventStart, DateTime EventEnd, string TimeZone, int Duration,
            string Recepients, bool isAllDayEvent, bool hasReminder, string ReminderType, int ReminderMinutes, bool isRecurring, int RecurrenceType, string RecurrenceDesc, DateTime RecurrenceStart, DateTime RecurrenceEnd,
            DateTime CreatedDate, DateTime ModifiedDate)
        {
            RefreshOutlookConstants();
            //ITEM TYPES
            var olMailItem = 0;
            var olAppointmentItem = 1;
            //
            //FOLDER TYPES
            var olFolderCalendar = 9;
            //
            int RecurrenceMask = 0;
            var objAppointment = objOutlook.CreateItem(olAppointmentItem);
            var objMail = objOutlook.CreateItem(olMailItem);
            var OlNamspace = objOutlook.GetNamespace("MAPI");
            var AppointmentFolder = OlNamspace.GetDefaultFolder(olFolderCalendar);
            var StoreID = AppointmentFolder.StoreID;
            AppointmentFolder.Items.IncludeRecurrences = true;
            string StatusTypeDesc = "";
            string[] Attendees = Recepients.Split(';');
            //UPDATE YEARLY RECURRENCE TYPE - BECAUSE THE NUMBER 4 DOES NOT EXIST ACCORDING TO MICROSOFT ( -_-)
            if (RecurrenceType == 3)
            {
                RecurrenceType = 5;
            }
            //GET DAY OF WEEK
            if (RecurrenceDesc.Trim().ToUpper() == "MONDAY")
            {
                RecurrenceMask = 32;
            }
            else if (RecurrenceDesc.Trim().ToUpper() == "TUESDAY")
            {
                RecurrenceMask = 4;
            }
            else if (RecurrenceDesc.Trim().ToUpper() == "WEDNESDAY")
            {
                RecurrenceMask = 8;
            }
            else if (RecurrenceDesc.Trim().ToUpper() == "THURSDAY")
            {
                RecurrenceMask = 16;
            }
            else if (RecurrenceDesc.Trim().ToUpper() == "FRIDAY")
            {
                RecurrenceMask = 32;
            }
            else if (RecurrenceDesc.Trim().ToUpper() == "SATURDAY")
            {
                RecurrenceMask = 64;
            }
            else if (RecurrenceDesc.Trim().ToUpper() == "SUNDAY")
            {
                RecurrenceMask = 1;
            }
            else
            {
                RecurrenceMask = 0;
            }
            //CHECK ALL DAY EVENT
            if (isAllDayEvent)
            {
                EventStart = Convert.ToDateTime(EventStart.ToString("dd/MM/yyyy") + " 12:00 AM");
                EventEnd = Convert.ToDateTime(EventEnd.AddDays(1).ToString("dd/MM/yyyy") + " 12:00 AM");
            }
            //--RESOLVE EVENT START - END - DURATION
            GetEventDates(EventStart, EventEnd, Duration, out EventEnd, out Duration);
            if (EventStart == null)
            {
                return EventID + "@FAIL";
            }
            //ADD - DELETE - UPDATE MEETING ACCORDINGLY
            if (StatusType == 'D')
            {
                var aObject = OlNamspace.GetItemFromID(EventID, StoreID);
                aObject.MeetingStatus = 5;
                aObject.Save();
                if (Recepients.Trim() != "")
                {
                    foreach (string attendee in Attendees)
                    {
                        if (attendee.Trim() != "")
                        {
                            string NewAttendee = ExtractEmail(attendee);
                            aObject.Recipients.Add(NewAttendee.Trim());
                        }
                    }
                    aObject.Send();
                }
                aObject.Delete();
                aObject = null;
            }
            else
            {
                if (StatusType == 'U')
                {
                    foreach (var aObject in AppointmentFolder.Items)
                    {
                        var EntryID = aObject.EntryID;
                        if (Convert.ToString(EntryID) == EventID.Trim())
                        {
                            aObject.MeetingStatus = 5;
                            aObject.Save();
                            if (Recepients.Trim() != "")
                            {
                                foreach (string attendee in Attendees)
                                {
                                    string NewAttendee = ExtractEmail(attendee);
                                    if (NewAttendee.Trim() != "")
                                    {
                                        aObject.Recipients.Add(NewAttendee.Trim());
                                    }
                                }
                                aObject.Send();
                            }
                            aObject.Delete();
                        }
                    }
                }
                objAppointment.MeetingStatus = 1;
                objAppointment.Subject = Subject;
                objAppointment.Body = Description;
                objAppointment.Location = Location;
                if (Recepients.Trim() != "")
                {
                    foreach (string attendee in Attendees)
                    {
                        string NewAttendee = ExtractEmail(attendee);
                        if (NewAttendee.Trim() != "")
                        {
                            objAppointment.Recipients.Add(NewAttendee.Trim());
                        }
                    }
                }
                if (isAllDayEvent)
                {
                    objAppointment.AllDayEvent = isAllDayEvent;
                }
                else
                {
                    objAppointment.Start = EventStart;
                    objAppointment.End = EventEnd;  //Optional if Event has Duration
                    objAppointment.Duration = Duration; //Optional if Event has Start and End
                }
                objAppointment.ReminderSet = hasReminder;
                if (hasReminder)
                { 
                    objAppointment.ReminderMinutesBeforeStart = ReminderMinutes;
                }
                objAppointment.Importance = 2;
                objAppointment.BusyStatus = 2;
                if (isRecurring)
                {
                    var pattern = objAppointment.GetRecurrencePattern();
                    pattern.RecurrenceType = RecurrenceType;
                    if (RecurrenceType == 1)
                    {
                        pattern.DayOfWeekMask = RecurrenceMask;
                    }
                    else if (RecurrenceType == 4)
                    {
                        pattern.MonthOfYear = RecurrenceMask;
                    }
                    if (DateTime.Compare(RecurrenceStart, DateTime.Now) > 1)
                    {
                        pattern.PatternStartDate = DateTime.Parse(RecurrenceStart.ToString("dd/MM/yyyy"));
                    }
                    if (DateTime.Compare(RecurrenceEnd, DateTime.Now) > 1)
                    {
                        pattern.PatternEndDate = DateTime.Parse(RecurrenceEnd.ToString("dd/MM/yyyy"));
                    }
                }
                objAppointment.Save();
                if (Recepients.Trim() != "")
                {
                    objAppointment.Send();
                }
                EventID = objAppointment.EntryID;
            }
            objAppointment = null;
            //objOutlook = null;
            // CREATE--UPDATE--DELETE EVENT OR APPOINTMENTS
            StatusTypeDesc = GetStatusType(StatusType).Trim();
            if (StatusTypeDesc == "")
            {
                clsGlobalFuncs.WriteServiceLog(String.Format("Error Creating Outlook Event: Unknown Status Type [{0}]. Event was Treated as a new event and may contain errors", StatusType));
                return EventID + "@FAIL";
            }
            clsGlobalFuncs.WriteServiceLog(String.Format("Outlook Event Succesfully {2}. [EventID: {0}] ][EventRef: {1}]", EventID, EventIDRef, StatusTypeDesc));
            return EventID + "@PASS";
        }
    public static void SendEmail(string Recepients, string CC, string BCC, string Subject, string Body, string Attachment)
        {
            RefreshOutlookConstants();
            string[] EmailArr = Recepients.Split(';');
            foreach (string email in EmailArr)
            {
                if (email.IndexOf('@') == -1)
                {
                    WriteServiceLog(String.Format("EMAIL ERROR: Invalid Email Address:- [{0}]. This email will be skipped", email));
                    Recepients = Recepients.Replace(email + ";", "");
                    Recepients = Recepients.Replace(email, "");
                }
            }
            if (Recepients.Trim() == "")
            {
                WriteServiceLog(String.Format("Error Sending Email. No recpients were found in string [{0}]", Recepients));
                return;
            }
            try
            {
                Recepients = StringClean(Recepients);
                // SEND EMAIL WITH ATTACHMENT
                mailObject.To = Recepients;
                if (CC.Trim() != "") { mailObject.CC = CC; }
                if (BCC.Trim() != "") { mailObject.BCC = BCC; }
                mailObject.Subject = Subject;
                mailObject.HTMLBody = Body;
                mailObject.Importance = 2;
                if (Attachment.Trim() != "")
                {
                    string[] attachmentList = Attachment.Split(';');
                    foreach (string attachmentFile in attachmentList)
                    {
                        if (attachmentFile.Trim() != "")
                        {
                            mailObject.Attachments.Add(attachmentFile.Trim());
                        }
                    }
                }
                mailObject.Send();
                //objEmail.Display(false);
                WriteServiceLog(String.Format("Email Sent [{0}] TO [{1}]", Subject, Recepients));
            }
            catch (Exception ex)
            {
                WriteServiceLog("Error sending email");
                WriteErrorLog(ex);
            }
        }
        public static string GetStatusType(char StatusCode)
        {
            string returnValue = "";
            if (StatusCode == 'A')
            {
                returnValue = "Created";
            }
            else if (StatusCode == 'U')
            {
                returnValue = "Updated";
            }
            else if (StatusCode == 'D')
            {
                returnValue = "Deleted";
            }
            return returnValue;      
        }
        public static string GetRecurData(bool RecurFlag, string EventType, int RecurrenceType, string RecurrenceDesc, DateTime RecurrenceStart, DateTime RecurrenceEnd, DateTime EventStart)
        {
            string returnValue = String.Format("RRULE:FREQ=DAILY;UNTIL={0:yyyyMMdd};", EventStart);
            if (RecurFlag == true)
            {
                returnValue = "";
                if (RecurrenceType == 0)
                {
                    returnValue = String.Format("{0}RRULE:FREQ=DAILY;", returnValue);
                }
                else if (RecurrenceType == 1)
                {
                    returnValue = returnValue + "RRULE:FREQ=WEEKLY;";
                }
                else if (RecurrenceType == 2)
                {
                    returnValue = returnValue + "RRULE:FREQ=MONTHLY;";
                }
                else
                {
                    returnValue = returnValue + "RRULE:FREQ=YEARLY;";
                }
                if (RecurrenceEnd != null)
                {
                    returnValue = String.Format("{0}UNTIL={1:yyyyMMdd}T{2:HHmmss}Z;", returnValue, RecurrenceEnd, RecurrenceEnd);
                }
                if (EventType == "GM")
                {
                    if (RecurrenceType == 1)
                    {
                        if ((RecurrenceDesc != null) && (RecurrenceDesc.Trim() != ""))
                        {
                            returnValue = String.Format("{0}BYDAY={1};", returnValue, RecurrenceDesc.Substring(0, 2).ToUpper());
                        }
                    }
                    if (RecurrenceType == 3)
                    {
                        int i = DateTime.ParseExact(RecurrenceDesc, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;
                        if ((RecurrenceDesc != null) && (RecurrenceDesc.Trim() != ""))
                        {
                            returnValue = String.Format("{0}BYMONTH={1};", returnValue, i);
                        }
                    }
                }
            }
            return returnValue;
        }
        public static string GetReminderType(bool ReminderFlag, string EventType, string ReminderCode)
        {
            string returnValue = "NONE";
            if (ReminderFlag == true)
            {
                if (ReminderCode.Trim() == "PROMPT")
                {
                    if (EventType == "GM")
                    {
                        returnValue = "popup";
                    }
                    else if (EventType == "OC")
                    {
                        returnValue = "DISPLAY";
                    }
                }
                else
                {
                    returnValue = "email";
                    if (EventType == "OC") { returnValue = returnValue.ToUpper(); }
                }
            }
            return returnValue;
        }
        public static void GetEventDates(DateTime EventStart, DateTime EventEnd, int Duration, out DateTime EventEnd_Ret, out int Duration_Ret)
        {
            EventEnd_Ret = EventEnd;
            Duration_Ret = 0;
            if (!(EventStart == null))
            {
                if (((EventEnd == null) || (DateTime.Compare(EventEnd, EventStart) < 1)) && (Duration > 0))
                {
                    EventEnd_Ret = EventStart.AddMinutes(Duration);
                }
                else if ((Duration_Ret <= 0) && ((EventEnd != null) && (DateTime.Compare(EventEnd, EventStart) >= 0)))
                {
                    Duration_Ret = Convert.ToInt32((EventEnd - EventStart).TotalMinutes);
                }
                if ((Duration_Ret <= 0) || ((EventEnd_Ret == null) || (DateTime.Compare(EventEnd_Ret, EventStart) < 1)))
                {
                    WriteServiceLog(String.Format("ERROR UPDATING EVENT - COULD NOT RESOLVE WHEN THE EVENT MUST END USING [END DATE: {0:dd/MM/yyyy HH:mm}] OR [DURATION: {1}] - PLEASE SPECIFY A VALID END DATE OR DURATION", EventEnd, Duration));
                }
            }
            else
            {
                WriteServiceLog("ERROR UPDATING EVENT - START DATE NOT FOUND");
            }
        }
        public static string StringClean(string StringValue)
        {
            StringValue = StringValue.Replace(':',' ');
            StringValue = StringValue.Replace('[', ' ');
            StringValue = StringValue.Replace(']', ' ');
            StringValue = StringValue.Replace('\'', ' ');
            StringValue = StringValue.Replace('<', ' ');
            StringValue = StringValue.Replace('>', ' ');
            return StringValue.Trim();
        }
