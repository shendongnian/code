    namespace X{  public static class URLs
    {
        public static TabController tabIdLookUp;
        public static string DASHBOARD_AUDIT_PAGE;
        public static string URL_GENERATE_WITH_MID(String TabName, int PortalId){        {
            return tabIdLookUp.GetTabByName(TabName, PortalId).TabID.ToString();
        }
    
        static URLs() {
            tabIdLookUp = new TabController();
            DASHBOARD_AUDIT_PAGE = tabIdLookUp.GetTabByName("View My Safety", 2).TabID.ToString();
        }
    }}
