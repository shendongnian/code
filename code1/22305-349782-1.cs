    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:TemplateField HeaderText="Button Field" ShowHeader="False">
                <ItemTemplate>
                    <span onclick="return ClientCheck();">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="IDClick" Text='<%# Eval("YourDataSourceItem") %>'></asp:LinkButton>
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            // ...your remaining columns...
