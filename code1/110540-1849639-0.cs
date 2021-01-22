        <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="false" 
            OnRowDataBound="gvTest_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Column 1">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbSelect1" runat="server" Text="" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Column 2">
                    <ItemTemplate>
                        <asp:RadioButton ID="rbSelect2" runat="server" Text="" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
