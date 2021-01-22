    <asp:LinqDataSource runat="server" ID="LinqDataSource1" ContextTypeName="Courses.DataClassesDataContext" TableName="Courses" EnableDelete="True" EnableUpdate="True" EnableInsert="True" />
    <h1>
        <a>
            Courses</a></h1>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
    </asp:UpdateProgress>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="course_id"
        DataSourceID="LinqDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None"
        BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowSorting="True" 
        ShowFooter="True">
        <Columns>
            <asp:BoundField DataField="course_id" HeaderText="course_id" ReadOnly="True" SortExpression="course_id"
                InsertVisible="False" />
            <asp:TemplateField HeaderText="name" SortExpression="name" >
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="NameTextBox" runat="server" />
                </FooterTemplate>
                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="credit_hours" SortExpression="credit_hours">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("credit_hours") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("credit_hours") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="HoursTextBox" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="dept" SortExpression="dept">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("dept") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("dept") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="DeptTextBox" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="class" SortExpression="class">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("class") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("class") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="ClassTextBox" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                        Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                        Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit"
                        Text="Edit"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete"
                        Text="Delete"></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:LinkButton ID="AddLinkButton" runat="server" CommandName="Add" Text="Add" CausesValidation="true" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {
                    // We are in a Postback so check to see if the AddLinkButton was clicked
                    String eventTarget = Request.Form["__EVENTTARGET"].ToString();
                    if (eventTarget.EndsWith("addlinkbutton",StringComparison.InvariantCultureIgnoreCase))
                    {
                        // We are adding a new row so build a ListDictionary with the controls from the footer row
                        ListDictionary values = new ListDictionary();
                        values.Add("name", ((TextBox)GridView1.FooterRow.FindControl("NameTextBox")).Text);
                        values.Add("credit_hours", ((TextBox)GridView1.FooterRow.FindControl("HoursTextBox")).Text);
                        values.Add("dept", ((TextBox)GridView1.FooterRow.FindControl("DeptTextBox")).Text);
                        values.Add("class", ((TextBox)GridView1.FooterRow.FindControl("ClassTextBox")).Text);
                        // Pass the ListDictionary to the data source to send off to the database
                        LinqDataSource1.Insert(values);
                        // Refresh the grid so it shows the row we just added
                        GridView1.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
