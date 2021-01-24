    using (ClientContext context = new ClientContext("https://domain.sharepoint.com/sites/Developer/"))
                {
                    string userName = "user.onmicrosoft.com";
                    string password = "pw";
                    SecureString securePassword = new SecureString();
                    foreach (char c in password.ToCharArray()) securePassword.AppendChar(c);
                    context.Credentials = new SharePointOnlineCredentials(userName, securePassword);
                    Web site = context.Web;
                    List list = site.Lists.GetByTitle("MyList2");
                    CamlQuery query = CamlQuery.CreateAllItemsQuery();
                    Microsoft.SharePoint.Client.ListItemCollection collection = list.GetItems(query);
                    context.Load(collection);
                    context.ExecuteQuery();
    
                    foreach (Microsoft.SharePoint.Client.ListItem item in collection)
                    {
                        string text = string.Format("{0}",item.FieldValues["Title"]);
                        modell.Items.Add(new System.Web.UI.WebControls.ListItem(text, item.Id.ToString()));
                    }
                    //modell.DataSource = collection;
                    //modell.DataValueField = "Printermodell";
                    //modell.DataTextField = "Printermodell";
                    //modell.DataBind();
                }
