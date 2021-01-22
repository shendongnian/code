    protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
    
                foreach (ListItem item in this.cbl.Items)
                {
                    item.Attributes.Add("onclick", "javascript:CheckBoxListClickHandler(this)");
                }
                
                this.cbl.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
            }
    
            void list_SelectedIndexChanged(object sender, EventArgs e)
            {
                string targetValue = "33";
                if (this.cblLastChecked.Value == targetValue)
                {
                    ListItem item = this.cbl.Items.FindByValue(targetValue);
                    if (item != null && item.Selected)
                    {
                        //Show Panel
                    }
                    else
                    {
                        //hide panel
                    }
                }
            }
