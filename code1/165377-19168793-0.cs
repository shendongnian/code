    using (var input = File.OpenRead(lstFiles[0]))
    {
        using (var ds = new SevenZipExtractor(input))
        {
            //ds.ExtractionFinished += DsOnExtractionFinished;
            var mem = new MemoryStream();
            ds.ExtractFile(0, mem);
            using (var sr = new StreamReader(mem))
            {
                var iCount = 0;
                String line;
                mem.Position = 0;
                while ((line = sr.ReadLine()) != null && iCount < 100)
                {
                    iCount++;
                    LstOutput.Items.Add(line);
                }
            }
        }
    } 
