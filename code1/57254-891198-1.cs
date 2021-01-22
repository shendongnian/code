        <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" 
            onselectedindexchanged="CheckBoxList1_SelectedIndexChanged">        
        </asp:CheckBoxList>
        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //first reset all to enabled
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                CheckBoxList1.Items[i].Attributes.Remove("disabled", "disabled");
            }
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    //get list of items to disable
                    string selectedService = CheckBoxList1.Items[i].Text;
                    List<string> servicesToDisable = getIncompatibleFor(selectedService);//this function is up to u
                    foreach (string service in servicesToDisable)
                    {
                        CheckBoxList1.Items.FindByText(service).Attributes.Add("disabled", "disabled");                                                
                    }                   
                }
            }
        }
