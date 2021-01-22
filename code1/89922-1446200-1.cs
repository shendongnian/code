    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string colId="",colr="";
        colId = e.Row.Cells[1].Text;
        colr = e.Row.Cells[2].Text;
    
        if (colId.Trim() != "Color Id" && colr.Trim() != "Color Name")
        {
            TextBox t = (TextBox)e.Row.FindControl("txtColor");
            if (t != null)
            {
                t.BackColor = System.Drawing.ColorTranslator.FromHtml(colId);
            }
        }
    }
    
    <asp:GridView id="GridView1" runat="server" BorderColor="Black" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" BackColor="Transparent">
        <columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="color_Id" HeaderText="Color Id"></asp:BoundField>
            <asp:BoundField DataField="color" HeaderText="Color Name"></asp:BoundField>
            <asp:TemplateField HeaderText="Color">
                <ItemTemplate>
                    &nbsp;<asp:TextBox ID="txtColor" runat="server" Enabled="False"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </columns>
    </asp:GridView>
