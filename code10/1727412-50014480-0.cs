    static void Main(string[] args)
            {            
                string login = "lee@domain.onmicrosoft.com"; //give your username here  
                string password = "pw"; //give your password  
                var securePassword = new SecureString();
                foreach (char c in password)
                {
                    securePassword.AppendChar(c);
                }
    
                string siteUrl = "https://domain.sharepoint.com/sites/tst";
                using (ClientContext clientContext = new ClientContext(siteUrl))
                {
                    clientContext.Credentials = new SharePointOnlineCredentials(login, securePassword);
                    var user = clientContext.Web.EnsureUser(login);
                    clientContext.Load(user);
                    clientContext.ExecuteQuery();
    
                    var list = clientContext.Web.Lists.GetByTitle("MyDoc3");
                    CamlQuery query = new CamlQuery();
                    //you could add query condition to query based on other conditions
                    query.ViewXml = "<View Scope='RecursiveAll'><Query><Where><And><BeginsWith><FieldRef Name='ContentTypeId'/><Value Type='ContentTypeId'>0x0101</Value></BeginsWith><Eq><FieldRef Name='Author' LookupId='True'/><Value Type='Lookup'>" + user.Id + "</Value></Eq></And></Where></Query></View>";                
                    var listItems = list.GetItems(query);
                    clientContext.Load(listItems);
                    clientContext.ExecuteQuery();
    
                    foreach (var item in listItems)
                    {
                        Console.WriteLine(item.FieldValues["FileRef"]);
                    }
    
                    Console.WriteLine("done");
                    Console.ReadLine();
                }
            }
