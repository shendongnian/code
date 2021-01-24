    <asp:GridView ID="gvFeatList" runat="server" AutoGenerateColumns="false" 
        ItemType="YourNameSpace.YourClass.FeatureDesc" DataKeyNames="ID" 
        OnRowCommand="gvFeatList_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <%# Item.Title %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tip">
                <ItemTemplate>
                    <%# Item.Tip %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tip">
                <ItemTemplate>
                    <asp:Button ID="editButton" runat="server" Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
