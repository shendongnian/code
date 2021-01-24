    static void Main(string[] args)
            {
                string _SiteUrl = "https://domain.sharepoint.com/sites/tst";
                using (var clientContext = new ClientContext(_SiteUrl))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    string password = "pw";
                    SecureString sec_pass = new SecureString();
                    Array.ForEach(password.ToArray(), sec_pass.AppendChar);
                    sec_pass.MakeReadOnly();
                    clientContext.Credentials = new SharePointOnlineCredentials("lee@domain.onmicrosoft.com", sec_pass);
    
                    Web web = clientContext.Web;
                    Folder folder = web.GetFolderByServerRelativeUrl("/sites/TST/MyDoc4/Folder");
                    var files = folder.Files;
                    clientContext.Load(files);
                    clientContext.ExecuteQuery();
                    Console.WriteLine();
                    //Regex regex = new Regex(_SiteUrl, RegexOptions.IgnoreCase);
    
                    var list = web.Lists.GetByTitle("MyDoc4");
                    var libRootFolder = list.RootFolder;
                    var subFolder = libRootFolder.Folders.GetByUrl("Folder");
                    clientContext.Load(libRootFolder);
                    clientContext.Load(subFolder);
                    clientContext.ExecuteQuery();
                    Console.WriteLine(libRootFolder.ItemCount);
                    Console.WriteLine(subFolder.ItemCount);
    
    
                    using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
                    {
                        using (var archive = new ZipArchive(mStream, ZipArchiveMode.Create, true))
                        {
                            foreach (var file in files)
                            {
                                clientContext.Load(file);
                                Console.WriteLine(file.Name);
                                ClientResult<Stream> stream = file.OpenBinaryStream();
                                clientContext.ExecuteQuery();
    
                                var zipArchiveEntry = archive.CreateEntry(file.Name);
                                using (Stream zipEntryStream = zipArchiveEntry.Open())
                                {
                                    
                                        if (stream != null)
                                        {
                                            stream.Value.CopyTo(zipEntryStream);
                                        }
                                    
                                }
                            }
                        }
                        using (var fileStream = new FileStream(@"C:\Lee\FileDownload\test.zip", FileMode.Create))
                        {
                            mStream.Seek(0, SeekOrigin.Begin);
                            mStream.CopyTo(fileStream);
                        }
                    }
    
    
                    Console.WriteLine("done");
                    Console.ReadKey();
                }
    
            }
