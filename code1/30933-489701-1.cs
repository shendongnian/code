    protected void datalistUWSolutions_UpdateCommand(object source, DataListCommandEventArgs e)
    {
      objDSSolutions.UpdateParameters["Name"].DefaultValue = ((Label)e.Item.FindControl("lblSolutionName")).Text;
      objDSSolutions.UpdateParameters["PriorityOrder"].DefaultValue = ((Label)e.Item.FindControl("lblOrder")).Text;
      objDSSolutions.UpdateParameters["Value"].DefaultValue = ((TextBox)e.Item.FindControl("txtSolutionValue")).Text;
      objDSSolutions.Update();
      datalistUWSolutions.EditItemIndex = -1; // Release the edited record
      datalistUWSolutions.DataBind();         // Redind the records for refesh the control
    }
