    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, ContactName, Country FROM Customers"))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    GridView1.DataSource = sdr;
                    GridView1.DataBind();
                }
                con.Close();
            }
        }
    }
     
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
    OnPageIndexChanging="OnPaging">
    <Columns>
        <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" />
        <asp:BoundField DataField="ContactName" HeaderText="ContactName" />
        <asp:BoundField DataField="Country" HeaderText="Country" />
    </Columns>
