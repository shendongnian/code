    public void Question2(bool IsPostBack)
    {
        if (!IsPostBack)
        {
            foo();
        }
        if (lsvnotificationList.Items.Count == 0)
        {
            foo();
        }
    }
