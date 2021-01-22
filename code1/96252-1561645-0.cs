    if(!IsPostBack)
    {
         for (int i = 1; i <= 100; i++) 
         { 
            var newItem = new ListItem(i.ToString());
            newItem.Selected = (i == 7);
            DropDownList1.Items.Add(i.ToString()); 
         }
    }
 
