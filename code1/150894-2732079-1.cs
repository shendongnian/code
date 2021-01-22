    public void DoStuffWithFile(string fileName)
    {
        using(FileStream fs = File.Open(fileName,...))
        {
            // Do Stuff
        }
    }
