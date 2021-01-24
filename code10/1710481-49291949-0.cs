        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="myLinkButton" runat="server" OnClick="myLinkButton_Click" CommandArgument='<%#Eval("userid")%>'>Click Me</asp:LinkButton>
                            </ItemTemplate>
        </asp:TemplateField>
    
    protected void myLinkButton_Click(object sender, EventArgs e)
            {
                string userid = (sender as LinkButton).CommandArgument;
                Response.Redirect("~/HereURL/course/" + userid);
            }
