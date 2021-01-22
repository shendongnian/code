    public class TestBL
    {
        public static void AddFolder(string folderName)
        {
            using (var ts = new TransactionScope())
            {
                using (var dc = new TestDataContext())
                {
                    var folder = new Folder { FolderName = folderName };
    
                    AddFile(dc, "test1.xyz", folder);
                    AddFile(dc, "test2.xyz", folder);
                    AddFile(dc, "test3.xyz", folder);
    
                    dc.SubmitChanges();
                }
    
                ts.Complete();
            }
        }
    
        private static void AddFile(DataContext dc, string filename, Folder folder)
        {
                dc.Files.InsertOnSubmit(
                    new File { Filename = filename, Folder = folder });
        }
        public static void AddFile(string filename, int folderId)
        {
            using (var dc = new TestDataContext())
            {
                var folder = new Folder { FolderId = folderId };
                dc.Attach(folder, false);
                AddFile(dc, filename, folder);
    
                dc.SubmitChanges();
            }
        }
    }
