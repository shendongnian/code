    using System;
    using System.Reflection;
    using Outlook = Microsoft.Office.Interop.Outlook;
     
    namespace RetrieveAppointment
    {
       public class Class1
       {
          public static int Main(string[] args)
          {
             try 
             {
                // Create the Outlook application.
                Outlook.Application oApp = new Outlook.Application();
     
                // Get the NameSpace and Logon information.
                // Outlook.NameSpace oNS = (Outlook.NameSpace)oApp.GetNamespace("mapi");
                Outlook.NameSpace oNS = oApp.GetNamespace("mapi");
     
                //Log on by using a dialog box to choose the profile.
                oNS.Logon(Missing.Value, Missing.Value, true, true); 
     
                //Alternate logon method that uses a specific profile.
                // TODO: If you use this logon method, 
                // change the profile name to an appropriate value.
                //oNS.Logon("YourValidProfile", Missing.Value, false, true); 
                
                // Get the Calendar folder.
                Outlook.MAPIFolder oCalendar = oNS.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
     
                // Get the Items (Appointments) collection from the Calendar folder.
                Outlook.Items oItems = oCalendar.Items;
                
                // Get the first item.
                Outlook.AppointmentItem oAppt = (Outlook.AppointmentItem) oItems.GetFirst();
     
     
                // Show some common properties.
                Console.WriteLine("Subject: " + oAppt.Subject);
                Console.WriteLine("Organizer: " + oAppt.Organizer);
                Console.WriteLine("Start: " + oAppt.Start.ToString());
                Console.WriteLine("End: " + oAppt.End.ToString());
                Console.WriteLine("Location: " + oAppt.Location);
                Console.WriteLine("Recurring: " + oAppt.IsRecurring);
       
                //Show the item to pause.
                oAppt.Display(true);
     
                // Done. Log off.
                oNS.Logoff();
     
                // Clean up.
                oAppt = null;
                oItems = null;
                oCalendar = null;
                oNS = null;
                oApp = null;
             }
     
                //Simple error handling.
             catch (Exception e)
             {
                Console.WriteLine("{0} Exception caught.", e);
             }  
     
             //Default return value
             return 0;
      
          }
       }
    }
