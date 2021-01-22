      protected void Page_Load()
        {
            if (!IsPostBack)
            {
                var querystringValue = Request.QueryString["Id"];
                if (!string.IsNullOrEmpty(querystringValue))
                {
                    // do something.
                }
            }
        }
