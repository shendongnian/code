    This way, you should implement an `OnCheckedChanged` event for your checbox which would add / remove itself from the viewstate of checked indexes. Now you would also have to implement an `OnItemDataBound` event to render the checkbox state from your viewstate. The last step would be in your button click to loop over the viewstate and perform your logic on each item.
        <asp:GridView ID="grdDisplayCMMData" runat="server" 
            AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="true" 
            CssClass="heavyTable table" EmptyDataText="No records to display"
            AllowPaging="true" PageSize="2" 
            OnPageIndexChanging="grdDisplayCMMData_PageIndexChanging">
            OnItemDataBound="grdDisplayCMMData_OnItemDataBound"
            <Columns>
                <asp:TemplateField HeaderText="Approve/Reject">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkApprRejCMM" runat="server" OnCheckedChange="chkApprRejCMM_OnCheckedChanged" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
        protected void chkApprRejCMM_OnCheckedChanged(object sender, EventArgs e)
        {
            if(ViewState["CheckedCheckboxes"] != null)
            {
                var CheckedCheckboxes = (List<int>)ViewState["CheckedCheckboxes"];
                var checkbox = (CheckBox)sender;
                var idLabel = (TextBox)checkbox.BindingContainer.FindControl("lblID_CMM");
                if(idLabel != null && !string.IsNullOrEmpty(idLabel.Text))
                {
                    if(checkbox.Checked)
                    {
                        if(!CheckedCheckboxes.Contains(idLabel.Text))
                            CheckedCheckboxes.Add(idLabel.Text);
                   }
                    else
                    {
                        if(CheckedCheckboxes.Contains(idLabel.Text))
                            CheckedCheckboxes.Remove(idLabel.Text)
                    }
                }
            }
        
        }
    
        protected void grdDisplayCMMData_OnItemDataBound(object sender, GridViewEventArgs e)
        {
            if(ViewState["CheckedCheckboxes"] != null)
            {
                var CheckedCheckboxes = (List<int>)ViewState["CheckedCheckboxes"];
                var checkbox = (CheckBox)e.item.FindControl("lchkApprRejCMM");
                var idLabel = (TextBox)e.item.FindControl("lblID_CMM");
                if(idLabel != null && checkbox != null && !string.IsNullOrEmpty(idLabel.Text))
                {
                    if(CheckedCheckboxes.Contains(idLabel.Text))
                        checbox.Checked = true;
                    else
                        checbox.Checked = false;
                }
            }
        }
    
        protected void YourButtonClick(object sender, EventArgs e)
        {
            if(ViewState["CheckedCheckboxes"] != null)
            {
                var CheckedCheckboxes = (List<int>)ViewState["CheckedCheckboxes"];
                foreach (var id in CheckedCheckboxes)
                {
                   //perform logic with id
                }
            }
        }
