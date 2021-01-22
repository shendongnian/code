    public void PersonDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            dynamic person = e.Item.DataItem as dynamic;
     
            string name = person.Name;
            int age = person.Age;
        }
    }
