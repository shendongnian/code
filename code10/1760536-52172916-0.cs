    while (reader.Read())
    {
        yearTotal += Convert.ToDecimal(reader["minTime"].ToString(), CultureInfo.InvariantCulture) + 0.00M;
        auxTotal += Convert.ToDecimal(reader["auxTime"].ToString(), CultureInfo.InvariantCulture) + 0.00M;
    }
    ListViewItem listItem = new ListViewItem(name);
    listItem.SubItems.Add(yearTotal.ToString());
    listItem.SubItems.Add(auxTotal.ToString());
    lstVwPeopleTime.Items.Add(listItem);
    name = "";
    return;
