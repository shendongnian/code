    Make all textbox properties set to visible false and then try in dropdown selection chagned event.
    <asp:TextBox ID="TextBox1" runat="server" visible="false"></asp:TextBox>
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (DropDownList1.SelectedItem.Text == "A")
        {
            TextBox2.Visible = false;
        }
      else
        TextBox2.Visible = true;
    }
