     public class NotificationEventArgs : EventArgs
        {
            public string Message{ get; set; }
            public NotificationEventArgs (string message)
            {
                Message= message;
            }
        }
