    <asp:DataGrid runat="server" ID="DataGrid1" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <asp:Image runat="server" ID="RowImage" />
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
    Private Sub DataGrid1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles DataGrid1.ItemDataBound
        Dim imageControl As Image
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            imageControl = DirectCast(e.Item.FindControl("RowImage"), Image)
            If MyValidationFunction() Then
                imageControl.ImageUrl = "icon1.gif"
            Else
                imageControl.ImageUrl = "icon2.gif"
            End If
        End If
    End Sub
