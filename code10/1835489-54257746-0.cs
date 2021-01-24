        namespace Api.Collection
    {
        public class Announcements : List<Announcement>
        {
            IConfiguration _config;
            ILoggerManager _logger;
    
            private string _uspGetAnnouncement = "storedproced_GetAnnouncemnt";
    
            public List<Announcement> announcements = new List<Announcement>();
            public Announcements()
            {
    
            }
            public Announcements(int employeeID, int moduleID, IConfiguration config, ILoggerManager logger)
            {
                _config = config;
                _logger = logger;
    
                if (employeeID > 0 && moduleID > 0)
                {
                    var value = Load(employeeID, moduleID);
                }
            }
    
            public virtual List<Announcement> Load(int employeeID, int moduleID)
            {     
                List<SqlParameter> lParam = new List<SqlParameter>();
    
                Util.DataUtil dataUtil = new Util.DataUtil(_config);
                SqlParameter param;
    
                if (employeeID > 0 && moduleID > 0)
                {
                    param = new SqlParameter("@employeeID", employeeID);
                    lParam.Add(param);
    
                    param = new SqlParameter("@moduleID", moduleID);
                    lParam.Add(param);
                }
    
                DataTable dt = Util.GetDataTable(_uspGetAnnouncement, lParam.ToArray());
    
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        announcements.Add(new Announcement(dr, dt.Rows.Count, _config, _logger));
                    }
                }
                return announcements;   *** this has 2 records
            }
        }
    }
