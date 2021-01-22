        Table TableId = new Table();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                TableId.ID = "MyTable";
            }
            else
            {
                TableId = (Table)Session["table"];
                this.form1.Controls.Add(TableId);
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Session["table"] = TableId; 
        }
        
        protected void btnAddinRow_Click(object sender, EventArgs e)
        {
            int num_row = (TableId.Rows).Count;
            TableRow r = new TableRow();
            TableCell c1 = new TableCell();
            TableCell c2 = new TableCell();
            TextBox t = new TextBox();
            t.ID = "textID" + num_row;
            t.EnableViewState = true;
            r.ID = "newRow" + num_row;
            c1.ID = "newC1" + num_row;
            c2.ID = "newC2" + num_row;
            c1.Text = "New Cell - " + num_row;
            c2.Controls.Add(t);
            r.Cells.Add(c1);
            r.Cells.Add(c2);
            TableId.Rows.Add(r);
            Session["table"] = TableId;
        }
