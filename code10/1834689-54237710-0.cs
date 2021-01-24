    <asp:Repeater ID="DepartmentsRepeater" runat="server">
            <ItemTemplate>
                <input class="departments" onclick="show(this)" type="checkbox" value="<%# Container.DataItem?.ToString() %>" /><%# Container.DataItem?.ToString() %> </br>
                <asp:Repeater ID="AreasRepeater" runat="server" DataSource='<%# GetAreasOfDepartment(Container.DataItem?.ToString()) %>'>
                    <ItemTemplate>
                        <div class="areas <%#((RepeaterItem)Container.Parent.Parent).DataItem?.ToString() %>">
                            <input type="checkbox" value="<%# Container.DataItem?.ToString() %>" /><%# Container.DataItem?.ToString() %> </br>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
        </asp:Repeater>
    
        <script>
            $(".areas").hide();
    
            function show(e) {
                $(".areas").hide();
                $(".departments").each(function (d) {
                    if (this.checked) {
                        var c = "." + this.value;
                        $(c).show();
                    }
                })
            }
        </script>
    public partial class _Default : Page
        {
            public List<string> Departments = new List<string> { "HR", "Finance" };
            public Dictionary<string, List<string>> Areas = new Dictionary<string, List<string>>
            {
                {"HR", new List<string>{"HR1","HR2"} },
                {"Finance", new List<string>{ "Finance1", "Finance2" } }
            };
            protected void Page_Load(object sender, EventArgs e)
            {
                this.DepartmentsRepeater.DataSource = Departments;
                this.DepartmentsRepeater.DataBind();
            }
            
            public List<string> GetAreasOfDepartment(string dep)
            {
                return Areas[dep];
            }
        }
