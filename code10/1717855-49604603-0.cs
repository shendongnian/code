    using (var context = new ClientContext("https://domain.sharepoint.com/sites/TST"))
                {                 
                    Console.ForegroundColor = ConsoleColor.Green;
                    string password = "pw";
                    SecureString sec_pass = new SecureString();
                    Array.ForEach(password.ToArray(), sec_pass.AppendChar);
                    sec_pass.MakeReadOnly();
                    context.Credentials = new SharePointOnlineCredentials("lee@domain.onmicrosoft.com", sec_pass);
    
                    CamlQuery myquery = new CamlQuery();
                    myquery.ViewXml = "<View Scope=\"RecursiveAll\">" +
                    "<Query>"+
                    "<Where>" +
                       "<Eq>" +
                            "<FieldRef Name='DocIcon' />" +
                             "<Value Type='Computed'>xls</Value>" +
                       "</Eq>" +
                    "</Where>"+
                    "</Query>"+
                     "</View>";
                    var docLibs = context.LoadQuery(context.Web.Lists.Where(l => l.BaseTemplate == 101));
                    context.ExecuteQuery();
                    foreach (var list in docLibs)
                    {
                        var result = list.GetItems(myquery);
                        context.Load(result, items => items.Include(
                            item => item["Title"],
                            item => item["FileRef"]
                        ));
                        //context.Load(result);
                        context.ExecuteQuery();
                        foreach(var file in result){                        
                            var fileRef = file["FileRef"];                        
                            FileInformation fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, fileRef.ToString());
                            context.ExecuteQuery();
    
                            var filePath = @"C:\Lee\FileDownload\" + fileRef.ToString().Split('/').Last();
                            using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                            {
                                fileInfo.Stream.CopyTo(fileStream);
                            }
                        }                    
                    }
                    
                    Console.WriteLine("done");
                    Console.ReadKey();
                }
