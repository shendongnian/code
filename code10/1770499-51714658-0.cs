    <asp:GridView ID="GridView1" runat="server" ItemType="System.DateTime" 
      OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Hour">
                <ItemTemplate>
                    <%# Item.ToLongTimeString() %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="00 Min">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Item %>'>O</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="15 Min">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Item.AddMinutes(15) %>'>O</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="30 Min">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# Item.AddMinutes(30) %>'>O</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="45 Min">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument='<%# Item.AddMinutes(45) %>'>O</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
