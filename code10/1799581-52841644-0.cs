    private void Write(string path, string txt, bool appendText=false)
    {
        try
        {
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (appendText)
            {
                // Appends the specified string to the file, creating the file if it does not already exist.
                File.AppendAllText(path, txt);
            }
            else
            {
                // Creates a new file, write the contents to the file, and then closes the file.
                // If the target file already exists, it is overwritten.
                File.WriteAllText(path, txt);
            }
        }
        catch (Exception ex)
        {
            //Log error
            Console.WriteLine($"Exception: {ex}");
        }
    }
