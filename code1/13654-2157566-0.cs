            List<ListItem> li = new List<ListItem>();
            foreach (ListItem list in DropDownList1.Items)
            {
                li.Add(list);
            }
            li.Sort((x, y) => string.Compare(x.Text, y.Text));
            DropDownList1.Items.Clear();
            DropDownList1.DataSource = li;
            DropDownList1.DataTextField = "Text";
            DropDownList1.DataValueField = "Value";
            DropDownList1.DataBind();
