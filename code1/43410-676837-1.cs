        //Property in masterpage base
        public string QsSearchTerm
        {
            get
            {
                if (!String.IsNullOrEmpty(Request.QueryString["q"]))
                {
                    return Helpers.SanitiseString(Server.UrlDecode(Request.QueryString["q"]));
                }
                return String.Empty;
            }
        }
        //Property in usercontrol base
        public string QsSearchTerm
        {
            get
            {
                if (Page.Master is BaseMasterPage)
                {
                    return ((BaseMasterPage)Page.Master).QsSearchTerm;
                }
                return string.Empty;
            }
        }
