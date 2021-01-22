    using (SPSite site = new SPSite("<site_url_where_list_is>"))
    {
        using (SPWeb web = site.OpenWeb())
        {
            SPList list = web.Lists["<list_name>"];
            foreach (SPListItem listItem in list.Items)
            {
                foreach (SPField field in list.Fields)
                {
                    object value = listItem[field.Id];
                    System.Diagnostics.Debug.WriteLine(field.Title + ": " + (value == null ? "(null)" : value.ToString()));
                }
            }
        }
    }
