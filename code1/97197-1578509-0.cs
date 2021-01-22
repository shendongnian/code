    SPList list = web.Lists["ListName"];
    //SPListItem item = list.Items.Add();
    //item["PercentComplete"] = .45; // 45%
    //item.Update();
    SPListItemCollection items = list.GetItems(new SPQuery()
    {
        Query = @"<Where>
                    <Eq>
                       <FieldRef Name='Title' />
                       <Value Type='Text'>Desigining</Value>
                    </Eq>
                  </Where>"
    });
    foreach (SPListItem item in items)
    {
        item["PercentComplete"] = .45; // 45%
        item.Update();
    }
