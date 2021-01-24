    private IEnumerable GetDirFiles(String location)
    {
        IEnumerable<string> emailfiles; // just declare the variable outside try..catch scope.
        try
        {
            //Search all directories for txt files
            emailfiles = Directory.EnumerateFiles(location, "*.txt", SearchOption.AllDirectories);
            // any other operations on emailfiles goes here
        }
        catch(Exception ex)
        {
            Console.WriteLine("Message for admins: " + ex.Message);
        }
        finally
        {
            textBox1.Clear();
            emailfiles = Directory.EnumerateFiles(location, "*.msg", SearchOption.AllDirectories);
        // any other operations on emailfiles goes here
        }
        return emailfiles;
    }
