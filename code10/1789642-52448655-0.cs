    protected void runReportForUser(Guid UserID)
        {
            pnCard.Visible = true;
            pnNoPoints.Visible = false;
            using (var db = new db())
            {
                // scorecard logic
                var u = userProfile.get(UserID);
                var t = db.Database.SqlQuery<EntityHistory>("exec dbo.ReturnEntities '" + u.userID.ToString() + "'");
                List<EntityHistory> EntityList = t.ToList<EntityHistory>();
                rptEvents.DataSource = EntityList;
                rptEvents.DataBind();
            }
        }
    protected void rptEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
            EntityHistory EH = (EntityHistory)e.Item.DataItem;
                ((Label)e.Item.FindControl("lblDate")).Text = EH.dateCompleted;
                ((Label)e.Item.FindControl("lblCategory")).Text = DataBinder.Eval(e.Item.DataItem, "Category").ToString();
                ((Label)e.Item.FindControl("lblName")).Text = DataBinder.Eval(e.Item.DataItem, "Name").ToString();
                ((Label)e.Item.FindControl("lblPointsValue")).Text = DataBinder.Eval(e.Item.DataItem, "MaxPointsEach").ToString();
            }
        }
    public class EntityHistory
    {
        public Guid UserID { get; set; }
        public String dateCompleted {get;set;}
        public String Category { get; set; }
        public String Name { get; set; }
        public Int32 MaxPointsEach { get; set; }
    }
