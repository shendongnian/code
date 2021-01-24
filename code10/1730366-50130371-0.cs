    CamlQuery camlQuery = new CamlQuery();
    camlQuery.ViewXml = @"<View Scope='RecursiveAll'>
    					  <Query>
    					  </Query>
    				  </View>";
    camlQuery.FolderServerRelativeUrl = folder.ServerRelativeUrl;
    ListItemCollection listItems = list.GetItems(camlQuery);
    clientContext.Load(listItems);
    clientContext.ExecuteQuery();
    
    var items = listItems.Where(i => i.FieldValues["FileLeafRef"].ToString().Equals("1.txt")||i.FieldValues["FileLeafRef"].ToString().Equals("2.txt")).ToList();
