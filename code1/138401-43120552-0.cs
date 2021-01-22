    public static void createZipFile(string inputfile, string outputfile, CompressionLevel compressionlevel)
            {
                try
                {
                    using (ZipArchive za = ZipFile.Open(outputfile, ZipArchiveMode.Update))
                    {
                        //using the same file name as entry name
                        za.CreateEntryFromFile(inputfile, inputfile);
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input/output file.");
                    Environment.Exit(-1);
                }
    }
