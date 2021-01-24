    static List<Change> changes = new List<Change>();
    class Change
        {
            public string control{ get; set; }
            public string style { get; set; }
        }
    protected void UpdateTimer_Tick(object sender, EventArgs e)
        {
            foreach (Change c in changes)
            {
                HtmlGenericControl control = (HtmlGenericControl)FindControl(c.room);
                control.Attributes["style"] = c.style;
            }
            changes = new List<Change>();
        }
