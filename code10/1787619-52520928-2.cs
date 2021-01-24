    string fileName=@"C:\test.mp4";
    using (var clientContext = new ClientContext(siturl))
    {
         using (var fs = new FileStream(fileName, FileMode.Open))
         {
             var fi = new FileInfo(fileName);
             var list = clientContext.Web.Lists.GetByTitle("Learning Materials2");
             clientContext.Load(list.RootFolder);
             clientContext.ExecuteQuery();
             var fileUrl = String.Format("{0}/{1}", list.RootFolder.ServerRelativeUrl, fi.Name);
             Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, fileUrl, fs, true);
         }
     }
