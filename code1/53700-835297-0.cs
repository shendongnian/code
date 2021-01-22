    using(TextWriter textWriter = new StreamWriter(
            System.IO.Path.Combine(Constants.APP_PATH, filename), true))
    {
        textWriter.WriteLine(log.ToString());
    }
