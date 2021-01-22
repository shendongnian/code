    <asp:DropDownList ID="MyDDL" runat="server">
        <asp:ListItem Value="A">1</asp:ListItem>
        <asp:ListItem Value="A">2</asp:ListItem>
        <asp:ListItem Value="A">3</asp:ListItem>
    </asp:DropDownList>
    private void AddExtraItemToList() {
        if (someCondition) // extra items may or may not be inserted
            MyDDL.Items.Add(new ListItem("17", "B");
    }
    private void RemoveExtraItemsFromList() {
        for (int x = MyDDL.Items.Count - 1; x > 0; --x) {
            if MyDDL.Items[x].Value = "B" {
                MyDDL.Items.RemoveAt(x);
            }
        }
    }
