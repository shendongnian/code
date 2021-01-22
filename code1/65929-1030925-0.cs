    <asp:GridView runat="server" ID="grdView" AutoGenerateColumns="False" 
            onrowcancelingedit="grdView_RowCancelingEdit" 
            onrowdatabound="grdView_RowDataBound" onrowediting="grdView_RowEditing">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:TemplateField HeaderText="IsActive Template">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblIsActive"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="chkIsActive" runat="server" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
        </asp:GridView>
