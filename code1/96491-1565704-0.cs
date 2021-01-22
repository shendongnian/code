    <asp:LinkButton runat="server" OnCommand="MyButton_Command" CommandArgument='<%# Eval("MyObjectId") %>'/>
    protected void MyButton_Command(object sender, CommandEventArgs e)
    {
        int myId = int.Parse(e.CommandArgument.ToString());
        // Load the object using the id passed in
    }
 
