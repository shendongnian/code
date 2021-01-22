      protected void Page_Load()
        {
            if (!IsPostBack)
            {
                var querystringValue = Request.QueryString["Id"];
                if (querystringValue != null)
                {
                    // do something.
                }
            }
        }
