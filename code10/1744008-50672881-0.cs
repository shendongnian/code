     public static Folder AddSubFolder(ClientContext context, Folder ParentFolder, string folderName)
            {
                Folder resultFolder=ParentFolder.Folders.Add(folderName);
                context.ExecuteQuery();
                return resultFolder;   
            }
    
            static void Main(string[] args)
            {
                using (var context = new ClientContext("https://domain.sharepoint.com/sites/TST/"))
                {
                    string password = "pw";
                    SecureString sec_pass = new SecureString();
                    Array.ForEach(password.ToArray(), sec_pass.AppendChar);
                    sec_pass.MakeReadOnly();
                    context.Credentials = new SharePointOnlineCredentials("lee@domain.onmicrosoft.com", sec_pass);               
    
                    Web web = context.Web;
                    var folders = web.DefaultDocumentLibrary().RootFolder.Folders;
                    context.Load(folders);
                    context.ExecuteQuery();
    
                    foreach (Folder subFolder in folders)
                    {
                        if (subFolder.Name == "98_Projekte")
                        {
                           Folder parent1= AddSubFolder(context,subFolder,"Muster Mandant");
                           AddSubFolder(context, parent1, "01 Test Subfolder");   
                        }
                    }
    
                    Console.WriteLine("Done");
                    Console.ReadKey();
                }
    
            }
