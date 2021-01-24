    Select Fruit:
    <asp:CheckBoxList ID="chkFruits" runat="server">
        <asp:ListItem Text="Apple" Value="1" />
        <asp:ListItem Text="Mango" Value="2" />
        <asp:ListItem Text="Papaya" Value="3" />
        <asp:ListItem Text="Banana" Value="4" />
        <asp:ListItem Text="Orange" Value="5" />
    </asp:CheckBoxList>
    <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick = "Submit" />
    protected void Submit(object sender, EventArgs e)
    {
        string message = "";
        foreach (ListItem item in chkFruits.Items)
        {
            if (item.Selected)
            {
                message += "Value: " + item.Value;
                message += " Text: " + item.Text;
                message += "\\n";
            }
        }
     
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);
    }
