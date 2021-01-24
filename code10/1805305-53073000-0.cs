    foreach (ListItem item in comboGroup.Items)
    {
        if (item.Selected)
        {
            var grp = new group_user();
            grp.username = comboUserName3.SelectedValue.ToString();
            string selectedItem = item.Value.ToString();
            int val = int.Parse(selectedItem);
            grp.groupid = val;
            //grp.iscurrent = true;
            grp.dateadded = DateTime.Now;
            db.group_user.Add(grp);
        }
    }
    db.SaveChanges();
