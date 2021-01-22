    protected void Page_Load()
        {
            if (!IsPostBack)
            {
                var sessionValue = Session["Id"];
                if (!string.IsNullOrEmpty(sessionValue))
                {
                    // do something.
                }
            }
        }
