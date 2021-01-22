      ListItem selected33 = CheckBoxList1.Items.Cast<ListItem>()
      .Where(item => item.Value == "33" && item.Selected).SingleOrDefault();
        if (selected33 != null)
        {
            Response.Write("33 is selected");
        }
