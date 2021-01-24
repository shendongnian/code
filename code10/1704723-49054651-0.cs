    const int HASHLENGTH = 40;
    
    static bool Check(string asHex, string filename)
    {
        using (var fs = File.OpenRead(filename))
        {
            var low = 0L;
            // We don't need to start at the very end
            var high = fs.Length - (HASHLENGTH - 1); // EOF - 1 HASHLENGTH
    
            StreamReader sr = new StreamReader(fs);
    
            while (low <= high)
            {
                var middle = (low + high + 1) / 2;
                fs.Seek(middle, SeekOrigin.Begin);
    
                // Resync with base stream after seek
                sr.DiscardBufferedData();
    
                var readLine = sr.ReadLine();
    
                // 1) If we are NOT at the beginning of the file, we may have only read a partial line so
                //    Read again to make sure we get a full line.
                // 2) No sense reading again if we are at the EOF
                if ((middle > 0) && (!sr.EndOfStream)) readLine = sr.ReadLine() ?? "";
    
                string[] parts = readLine.Split(':');
                string hash = parts[0];
    
                // By default string compare does a culture-sensitive comparison we may not be what we want?
                // Do an ordinal compare (0-9 < A-Z < a-z)
                int compare = String.Compare(asHex, hash, StringComparison.Ordinal);
    
                if (compare < 0)
                {
                    high = middle - 1;
                }
                else if (compare > 0)
                {
                    low = middle + 1;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
