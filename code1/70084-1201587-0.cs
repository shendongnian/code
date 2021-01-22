    protected void Page_Load(object sender, EventArgs e)
    {
        for(int i=0;i<5;i++)
        {
            InnerUserControl cuc = (InnerUserControl)this.Page.LoadControl("InnerUserControl.ascx");
            holder.Controls.Add(cuc);
        }
     }
