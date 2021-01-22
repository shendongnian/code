    public void GetDocumentStructure(int documentID)
        {
            string scmRepoPath = ConfigurationManager.AppSettings["SCMRepositoryFolder"];
            string docFilePath = scmRepoPath + "\\" + documentID.ToString() + ".xml";
            string docFilePath2 = scmRepoPath + "\\" + documentID.ToString() + "_clean.xml";
            Tidy tidy = new Tidy();
            tidy.Options.MakeClean = true;
            tidy.Options.NumEntities = true;
            tidy.Options.Xhtml = true;
            // this option removes the DTD on the generated output of Tidy
            tidy.Options.DocType = DocType.Omit;
            FileStream input = new FileStream(docFilePath, FileMode.Open);            
            MemoryStream output = new MemoryStream();
            TidyMessageCollection msgs = new TidyMessageCollection();
            tidy.Parse(input, output, msgs);            
            output.Seek(0, SeekOrigin.Begin);
                       
            XmlReader rd = XmlReader.Create(output);            
            int node = 0;
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            while (rd.Read())
            {                
                ++node;                
            }
            watch.Stop();
            Console.WriteLine("Duration was : " + watch.Elapsed.ToString());
        }
