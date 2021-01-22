    private static void UpdateJadProperties(Uri jadUri, Uri jarUri, Uri notifierUri)
        {
            Dictionary<String, String> dictionary;
    
            try
            {
                String[] jadFileContent;
    
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(jadUri.AbsolutePath.ToString()))
                {
                    Char[] delimiters = { '\r', '\n' };
                    jadFileContent = sr.ReadToEnd().Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
                    throw new Exception();
                }
    
                // @@NOTE: Keys contain ": " suffix, values don't!
                //dictionary = jadFileContent.ToDictionary(x => x.Substring(0, x.IndexOf(':') + 2), x => x.Substring(x.IndexOf(':') + 2));
    
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
    
            try
            {
                if (dictionary.ContainsKey("MIDlet-Jar-URL: "))
                {
                    // Change the value by Remove follow by Add
    
                }
            }
            catch (ArgumentNullException ane)
            {
    
                throw;
            }
    
        }
