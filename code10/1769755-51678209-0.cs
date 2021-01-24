    private IEnumerable GetDirFiles(String location)
    {
        try
        {
            //Search all directories for txt files
            return Directory.EnumerateFiles(location, "*.txt", SearchOption.AllDirectories);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Message for admins: " + ex.Message);
        }        
        finally
        {
            textBox1.Clear();
            return Directory.EnumerateFiles(location, "*.msg", SearchOption.AllDirectories);
        }
    }
