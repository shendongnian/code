    public void setMasterPage(Page page, HttpContext context)
        /***********************************************************************
         * Author   Daniel Tweddell
         * Date     9/18/09
         * 
         * Several of the pages are for non-admin use, however these pages will
         * also be used by the admin users and will need to have the admin menu
         * and such.  So based on the login, we either show the page with the
         * standard master or if the user is admin, use the admin master.
         ***********************************************************************/
        {
            if (context.Handler is IReadOnlySessionState || context.Handler is IRequiresSessionState)
            {
                context.Handler = Handler();
            }
            String sMasterPage="~/content/page.master";
            if (userinfo.IsUserAdmin) sMasterPage="~/content/administrator/admin.master";//make sure the user is admin
            page.MasterPageFile = sMasterPage; 
        }
