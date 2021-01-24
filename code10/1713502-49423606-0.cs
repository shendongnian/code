    <telerik:RadGrid ID="RadGrid1" runat="server" OnItemDataBound="RadGrid1_OnItemDataBound">
                <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed" DataKeyNames="fk_recId">
                    <Columns>
                        <telerik:GridBoundColumn UniqueName="ShipName" DataField="data_dummy"></telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="Check">
                            <ItemTemplate>
                               <asp:CheckBox runat="server" ID="cb"/>
                           </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
    protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    
                    AnotherSample();
                    BindTable();
                }
            }
            private void BindTable()
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new []{new DataColumn("fk_recId"),new DataColumn("data_dummy")});
                for (int i = 0; i < 10; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["fk_recId"] = i + 1;
                    dr["data_dummy"] = "data" + i + 1;
                    dt.Rows.Add(dr);
                }
                RadGrid1.DataSource = dt;
                RadGrid1.DataBind();
            }
    
            protected void RadGrid1_OnItemDataBound(object sender, GridItemEventArgs e)
            {
                if (e.Item is GridDataItem)
                {
                    GridDataItem item = e.Item as GridDataItem;
                    string strID = item.GetDataKeyValue("fk_recId").ToString();
                    if(((DataTable)ViewState["dt"]).AsEnumerable().Any(i=>i["fk_recId2"].ToString()== strID))
                    {
                        CheckBox shouldCheck = (CheckBox)item.FindControl("cb");
                        shouldCheck.Checked = true;
                    }
                }
            }
    
            private void AnotherSample()
            private void AnotherSample()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new[] { new DataColumn("fk_recId2"), new DataColumn("data_dummy") });
            for (int i = 0; i < 2; i++)
            {
                DataRow dr = dt.NewRow();
                dr["fk_recId2"] = i + 1;
                dr["data_dummy"] = "data" + i + 1;
                dt.Rows.Add(dr);
            }
            DataRow drq = dt.NewRow();
            drq["fk_recId2"] = 100;
            drq["data_dummy"] = "data";
            dt.Rows.Add(drq);
            ViewState["dt"] = dt;
        }
