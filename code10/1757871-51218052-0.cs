        protected void AddItemClick(object sender, EventArgs e)
        {
            List<UserEntry> ue = (List<UserEntry>)ListItems.DataSource;
            if(ue == null)
            {
               ue = new List<UserEntry>();
            }
            ue.Add(new UserEntry());
            ListItems.DataSource = ue;
            ListItems.DataBind();
        } // Just an idea though
