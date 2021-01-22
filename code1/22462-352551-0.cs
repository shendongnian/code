    public static byte[] ToXpsDocument(IEnumerable<FixedPage> pages)
    {
        // XPS DOCUMENTS MUST BE CREATED ON STA THREADS!!!
        // Note, this is test code, so I don't care about disposing my memory streams
        // You'll have to pay more attention to their lifespan.  You might have to 
        // serialize the xps document and remove the package from the package store 
        // before disposing the stream in order to prevent throwing exceptions
        byte[] retval = null;
        Thread t = new Thread(new ThreadStart(() =>
        {
            // A memory stream backs our document
            MemoryStream ms = new MemoryStream(2048);
            // a package contains all parts of the document
            Package p = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);
            // the package store manages packages
            Uri u = new Uri("pack://TemporaryPackageUri.xps");
            PackageStore.AddPackage(u, p);
            // the document uses our package for storage
            XpsDocument doc = new XpsDocument(p, CompressionOption.NotCompressed, u.AbsoluteUri);
            // An xps document is one or more FixedDocuments containing FixedPages
            FixedDocument fDoc = new FixedDocument();
            PageContent pc;
            foreach (var fp in pages)
            {
                // this part of the framework is weak and hopefully will be fixed in 4.0
                pc = new PageContent();
                ((IAddChild)pc).AddChild(fp);
                fDoc.Pages.Add(pc);
            }
            // we use the writer to write the fixed document to the xps document
            XpsDocumentWriter writer;
            writer = XpsDocument.CreateXpsDocumentWriter(doc);
            // The paginator controls page breaks during the writing process
            // its important since xps document content does not flow 
            writer.Write(fDoc.DocumentPaginator);
            // 
            p.Flush();
 
            // this part serializes the doc to a stream so we can get the bytes
            ms = new MemoryStream();
            var writer = new XpsSerializerFactory().CreateSerializerWriter(ms);
            writer.Write(doc.GetFixedDocumentSequence());
 
            retval = ms.ToArray();
        }));
        // Instantiating WPF controls on a MTA thread throws exceptions
        t.SetApartmentState(ApartmentState.STA);
        // adjust as needed
        t.Priority = ThreadPriority.AboveNormal;
        t.IsBackground = false;
        t.Start();
        //~five seconds to finish or we bail
        int milli = 0;
        while (buffer == null && milli++ < 5000)
            Thread.Sleep(1);
        //Ditch the thread
        if(t.IsAlive)
            t.Abort();
        // If we time out, we return null.
        return retval;
    }
