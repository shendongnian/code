         <asp:ScriptManager runat="server" ID="ScriptManager1" >
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DataGrid ID="DataGrid1" runat="server">
                    <Columns>
                        <asp:BoundColumn HeaderText="SomeColumn1" DataField="SomeColumn1" />
                        <asp:BoundColumn HeaderText="SomeColumn2" DataField="SomeColumn2" />
                        <asp:BoundColumn HeaderText="SomeColumn3" DataField="SomeColumn3" />
                    </Columns>
                </asp:DataGrid>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DataGrid1" />
            </Triggers>
         </asp:UpdatePanel>
