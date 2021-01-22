    public void Question2(bool IsPostBack)
    {
        if (!IsPostBack || lsvnotificationList.Items.Count == 0)
        {
            foo();
        }
    }
