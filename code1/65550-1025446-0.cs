    private static bool modifyFile(FileInfo file, string extractedMethod, string modifiedMethod)
    {
        try
        {
            string contents = File.ReadAllText(file.FullName);
            Console.WriteLine("input : {0}", contents);
            contents = contents.Replace(extractedMethod, modifiedMethod);
            Console.WriteLine("replaced String {0}", contents);
            File.WriteAllText(file.FullName, contents);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }
    }
