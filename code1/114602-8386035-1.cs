     protected void lbRemove_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Remove":
                    Recipients.Remove(e.CommandArgument.ToString());
                    rptRecipients.DataSource = Recipients;
                    rptRecipients.DataBind();
                    break;
            }
        }
