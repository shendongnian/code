     <form id="form1" runat="server">
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
            onselectedindexchanged="CheckBoxList1_SelectedIndexChanged">
            <asp:ListItem Value="33">33</asp:ListItem>
            <asp:ListItem Vaue="Not 33">Not 33</asp:ListItem>
        </asp:CheckBoxList>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        </form>
      protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write((sender as CheckBoxList).SelectedValue); // prints 33 if 33 is selected
        }
