    <div class="TABLE">
            <div class="ROW">
                <div class="CELL CELL50">
                    <asp:CheckBoxList ID="cblDepts" runat="server" OnSelectedIndexChanged="cblDepts_SelectedIndexChanged" AutoPostBack="True"></asp:CheckBoxList>
                </div>
                <div class="CELL CELL50">
                    <asp:CheckBoxList ID="cblAreas" runat="server" Visible="false">
                    </asp:CheckBoxList>
                </div>
            </div>
        </div>
    public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!this.IsPostBack)
                {
                    this.cblDepts.Items.Add(new ListItem() { Text = "1", Value = "1" });
                    this.cblDepts.Items.Add(new ListItem() { Text = "2", Value = "2" });
                    this.cblDepts.Items.Add(new ListItem() { Text = "3", Value = "3" });
                }
            }
    
            protected void cblDepts_SelectedIndexChanged(object sender, EventArgs e)
            {
                this.cblAreas.Items.Clear();
                foreach (ListItem item in this.cblDepts.Items) {
                    var selectedValue = "-1";
                    if (item.Selected)
                    {
                        selectedValue = item.Value;
                    }
    
                    if (selectedValue == "1")
                    {
                        this.cblAreas.Items.Add(new ListItem() { Text = "1.1", Value = "1.1" });
                    }
                    else if (selectedValue == "2")
                    {
                        this.cblAreas.Items.Add(new ListItem() { Text = "2.2", Value = "2.2" });
                    }
                    else if (selectedValue == "3")
                    {
                        this.cblAreas.Items.Add(new ListItem() { Text = "3.3", Value = "3.3" });
                    }
                }
    
                if (this.cblAreas.Items == null || this.cblAreas.Items.Count == 0)
                {
                    this.cblAreas.Visible = false;
                }
                else
                {
                    this.cblAreas.Visible = true;
                }
                
            }
        }
