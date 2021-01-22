    public partial class taskManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
    
            // Run after midnight
            if (dt.Hour == 0 && dt.Minute <= 15)
            {
                Write2Log("Schedule Job Started", LogType.INFO);
    
                SendSMSFromList(
                    GetUsersList(), 
                    GetSMSMessage());
    
                Write2Log("Schedule Job Finished", LogType.INFO);
            }
        }
    
        private string GetSMSMessage()
        { 
            // Fetch the text from DB...
    
            return "This is the message content that I will send as SMS"; 
        }
    
        private List<string> GetUsersList()
        { 
            // fetch the list form DB...
    
            return new List<string>(); 
        }
    
        private void SendSMSFromList(List<string> usersList, string message)
        { 
            // send SMS's
            foreach (string phoneNr in usersList)
            { 
                // send message
                mySMSAPI.Send(phoneNr, message);
            }
        }
    
        private void Write2Log(string text, LogType type)
        { 
            // Log to a file what's going on...
            try
            {
                string filename = HttpContext.Current.Server.MapPath("") + "status.log";
                using (StreamWriter sw = new StreamWriter(filename, true))  // open to append
                {
                    // example: 2008-12-17 13:53:10,462 INFO - Schedule Job Finished
                    string write = String.Format("{0} {1} - {2}",
                                    DateTime.Now,
                                    type.ToString(),
                                    text);
    
                    sw.WriteLine(write);
                }
            }
            catch (Exception)
            { }
        }
    
        private enum LogType
        { INFO, WARNING, ERROR }
    }
