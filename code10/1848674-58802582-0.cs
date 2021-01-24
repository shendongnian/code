     private void _meetingFolder_BeforeItemMove(object item, Outlook.MAPIFolder moveTo, ref bool cancel) 
     {  
         if (item is Outlook.AppointmentItem appointmentItem)
         {
             // some code 
         }
         else if (item is Outlook.MeetingItem meeting)
         {
             // some code 
         }
     }
     
