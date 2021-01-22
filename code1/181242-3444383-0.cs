    using (FileStream fs = File.OpenRead(@"c:\path\filename.txt")) //Open the file here
    {
        using (StreamReader sr = new StreamReader(fs))
        {
            while (!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
            }
        }
    } //File will close when scope of this brace ends.
