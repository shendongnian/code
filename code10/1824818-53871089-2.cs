    <asp:GridView ID="GridView1" runat="server" ItemType="YourNameSpace.MasterClass">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%# Item.subClass1 != null ? Item.subClass1.id : Item.subClass2.ID %>
                    <%# Item.subClass1 != null ? Item.subClass1.name : Item.subClass2.NAME %>     
                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
