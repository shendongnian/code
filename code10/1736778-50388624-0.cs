    public class NotificationData
    {
         public int NotificationCount {get;set;}
         public int ModuleName {get;set;}
    }
    public  class NotificationService
    {
        public static List<NotificationData> GetNotificationData(string username)
        {
            var notificationList = new List<NotificationData>();
            using (con = new SqlConnection(EXCUSESLPCON))
            {
                using (cmd = new SqlCommand("SYSTEMNOTIFICATIONEXSLIP", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userfullname", Fullname.Text);
                    con.Open();
                    using(adp = new SqlDataAdapter(cmd))
                    {
                        using(dt = new DataTable())
                        {
                            for (int i = 0; i < dt.Rows.Count; i++ )
                            {
                                var notification = new NotificationData();
                                notification.NotificationCount = int.Parse(dt.Rows[i]["notifcount"].ToString());
                                 notification.ModuleName = dt.Rows[i]["modulename"].ToString();
                            }
                        }
                    }
                }
            }
            return notificationList
        }
    }
