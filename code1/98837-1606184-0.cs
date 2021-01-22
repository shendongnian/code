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
        }
    
        private enum LogType
        { INFO, WARNING, ERROR }
    }
