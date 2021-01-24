       public void sendIncommingEvent(string s)
        {
            try
            {
             
                HttpContext.Current.Response.ContentType = "text/event-stream";
                HttpContext.Current.Response.Write("data:" + s.ToString() + "\n\n");
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
            }
        }
     public class NotificationEventArgs : EventArgs
        {
            public string Message{ get; set; }
            public NotificationEventArgs (string message)
            {
                Message= message;
            }
        }
