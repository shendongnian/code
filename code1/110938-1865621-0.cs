            public string[] OriginalDropDownValues
            {
                get
                {
                    return ViewState["origValues"] as string[];
                }
                set
                {
                    ViewState.Add("origValues", value);
                }
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    // get the values from the control and store them in viewstate
                    var oValues = new List<string>();
                    foreach (ListItem item in MyDDL.Items)
                    {
                        oValues.Add(item.Value);
                    }
                    OriginalDropDownValues = oValues.ToArray();
                }
            }
    
            // on postback 2
            private void RemoveExtraItemsFromList()
            {
                List<string> valuesToKill = new List<string>();
                var oItems = OriginalDropDownValues;
                foreach (ListItem currentItem in MyDDL.Items)
                {
                    if (!oItems.Contains(currentItem.Value))
                    {
                        // can't remove items yet, would modify collection we are iterating through
                        valuesToKill.Add(currentItem.Value);
                        
                    }
                }
                foreach (var killVal in valuesToKill)//loop kill values and locate+remove each from drop down.
                {
                    MyDDL.Items.Remove(MyDDL.Items.FindByValue(killVal));
                }
            }
