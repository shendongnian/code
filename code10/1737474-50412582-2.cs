     <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>
    </form>
    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Bind();
            }
        }
    protected void Bind() {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("Name", typeof(string));
            DataColumn dc2 = new DataColumn("Path", typeof(string));
            dt.Columns.Add(dc);
            dt.Columns.Add(dc2);
            DataRow dr = dt.NewRow();
            dr["Name"] = "1";
            dr["Path"] = Server.MapPath("ProDinner1.pdf");
            DataRow dr2 = dt.NewRow();
            dr2["Name"] = "2";
            dr2["Path"] = Server.MapPath("ProDinner2.pdf");
            dt.Rows.Add(dr);
            dt.Rows.Add(dr2);
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Path";
            DropDownList1.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = DropDownList1.SelectedValue.ToString();
            Session["path"] = path;
            Response.Write("<script language=javascript>window.open('show.aspx')</script>");
   
        }
