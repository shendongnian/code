    <asp:GridView ID="GridView1" runat="server" ItemType="System.IO.FileInfo" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="FileName">
                <ItemTemplate>
                    <%# Item.Name %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Size">
                <ItemTemplate>
                    <%# string.Format("{0:N1}", (decimal)Item.Length / 1024) %> kb
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Modified">
                <ItemTemplate>
                    <%# Item.LastWriteTime.ToLongDateString() %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
