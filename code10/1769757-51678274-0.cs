    private IEnumerable<string> GetDirFiles(String location)
    {
        IEnumerable<string> emailfiles = Enumerable.Empty<string>();
        try
        {
            //Search all directories for txt files
            emailfiles = Directory.EnumerateFiles(location, "*.txt", SearchOption.AllDirectories);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Message for admins: " + ex.Message);
        }
        finally
        {
            textBox1.Clear();
            emailfiles = Directory.EnumerateFiles(location, "*.msg", SearchOption.AllDirectories);
        }
        return emailfiles;
    }
