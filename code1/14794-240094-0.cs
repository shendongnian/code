    public class DashboardTabPage : TabPage
    {
        public List<DashboardItem> DashboardItems { get; set; }
    
        public DashboardTabPage() : this (new List<DashboardItem>())
        {
    
        }
    
        public DashboardTabPage(List<DashboardItem> items) :base ("Dashboard Item")
        {
            DashboardItems = items;
        }
       
    }
