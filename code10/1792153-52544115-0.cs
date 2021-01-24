    List<ListItem> listHours = new List<ListItem>();
    for (int hr = 0; hr < 25; hr++)
    {
         listHours.Add(new ListItem(hr.ToString(), hr.ToString()));
    }
    myDropDownList.Items.AddRange(listHours.ToArray());
