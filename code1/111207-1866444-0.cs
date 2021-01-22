    public static void CompactAndRepair(string accessFile, Microsoft.Office.Interop.Access.Application app)
            {
                string tempFile = Path.Combine(Path.GetDirectoryName(accessFile),
                                  Path.GetRandomFileName() + Path.GetExtension(accessFile));
    
                app.CompactRepair(accessFile, tempFile, false);
                app.Visible = false;
    
                FileInfo temp = new FileInfo(tempFile);
                temp.CopyTo(accessFile, true);
                temp.Delete();
            }
