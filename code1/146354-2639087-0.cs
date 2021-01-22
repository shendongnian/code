    <asp:TextBox ID="txtDouble" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ErrorMessage="Input must contain a double." ControlToValidate="txtDouble" 
            Operator="DataTypeCheck" SetFocusOnError="True" Type="Double"></asp:CompareValidator>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
    /*C#*/
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            double d = double.Parse(txtDouble.Text);
        }
    }
