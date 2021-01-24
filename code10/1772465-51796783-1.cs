     List list = clientContext.Web.Lists.GetByTitle("CustomList1");
                CamlQuery camlQuery = new CamlQuery();
                camlQuery.ViewXml = "<View><RowLimit>1200</RowLimit></View>";
                ListItemCollection collListItem = list.GetItems(camlQuery);
    
       
         clientContext.Load(collListItem, li => li.Include( 
                            pi => pi.Client_Title
                //pi => pi["Application"],
                // pi => pi["JobTitle"]
                // pi => pi["AIR_x0020_ID"]
                ));
            //clientContext.ExecuteQueryAsync();
            Task t2 = clientContext.ExecuteQueryAsync();
            await t2.ContinueWith((t) =>
            {
                foreach (ListItem oListItem in collListItem)
                {
                    { System.Diagnostics.Debug.WriteLine(oListItem.Client_Title); }
                }
                Console.ReadLine();
            });
