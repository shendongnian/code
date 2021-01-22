    SPList list = site.RootWeb.Lists["Countries"];
    var countries = from SPListItem li in list.Items
                    select new {
                        CountryName = li["CountryName"],
                        CountryCode = li["CountryCode"]
                    };
    ddl.DataSource = countries;
    ddl.DataTextField="CountryName";
    ddl.DataValueField="CountryCode";
    ddl.DataBind();
    
