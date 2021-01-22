    if (!Page.IsPostBack) {
                if (!Column.IsRequired) {
                    DropDownList1.Items.Add(new ListItem("[Not Set]", NullValueString));
                }
                if (Column.IsFilterDisabled()) {
                   
                    DropDownList1.Items.Add(new ListItem(DefaultValue, DefaultValue));
                }
                else {
                    PopulateListControl(DropDownList1);
                }
                // Set the initial value if there is one
                string initialValue = DefaultValue;
                if (!String.IsNullOrEmpty(initialValue)) {
                    DropDownList1.SelectedValue = initialValue;
                }
            }
        }
