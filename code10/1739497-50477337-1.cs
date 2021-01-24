    protected void game1_Validation(object sender, ServerValidateEventArgs args)
        {
            CustomValidator CustomValidator1 = (CustomValidator)sender;
            bool itemSelected = false;
            RepeaterItem ri = (RepeaterItem)CustomValidator1.Parent;         
            {
                if (ri is RadioButton)
                {
                    RadioButton rb = (RadioButton)ri.FindControl("gnOption11");
                    if (rb.GroupName == "gnOption1" && rb.Checked == true)
                    {
                        itemSelected = true;
                    }
                }
            }
            args.IsValid = itemSelected;
        }
