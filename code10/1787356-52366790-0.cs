    1. Your Select Button code --> <asp:Button ID="Button2"  runat="server" CausesValidation="false" Text="Select" CommandName="GetRec"></asp:Button>  
    
        public void gvObject_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "GetRec")
            {
                Label lblName = (Label)gvObject.FindControl("Name");
                Label lblBCC = (Label)gvObject.FindControl("BCC");
            }
        }
