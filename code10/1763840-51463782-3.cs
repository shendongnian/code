    static void readXps(byte[] originalXPS)
    {
        try
        {
            using (MemoryStream inputStream = new MemoryStream(originalXPS))
            {
                string memoryStreamUri = "memorystream://" + Path.GetFileName(Guid.NewGuid().ToString() + ".xps");
                Uri packageUri = new Uri(memoryStreamUri);
                using(Package oldPackage = Package.Open(inputStream))
                {
                    PackageStore.AddPackage(packageUri, oldPackage);
                    using(XpsDocument xpsOld = new XpsDocument(oldPackage, CompressionOption.Normal, memoryStreamUri))
                    {
                        FixedDocumentSequence seqOld = xpsOld.GetFixedDocumentSequence();
     
                        //The following did solve some of the memory issue
                        //-----------------------------------------------
                        var docPager = seqOld.DocumentPaginator;
                        docPager.ComputePageCount();
                        for (int i = 0; i < docPager.PageCount; i++)
                        {
                            FixedPage fp = docPager.GetPage(i).Visual as FixedPage;
                            fp.UpdateLayout();
                        }
                        seqOld = null;
                        //-----------------------------------------------           
                    } // disposes XpsDocument
                } // dispose Package
                PackageStore.RemovePackage(packageUri);
             } // dispose MemoryStream
        }
        catch (Exception e)
        {
            // really do something here, at least:
            Debug.WriteLine(e);
        }
    }
