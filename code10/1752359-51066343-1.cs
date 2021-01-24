    [Test]
    public void CreateLogOutput()
    {
        // create properties
        NameValueCollection properties = new NameValueCollection();
        properties["showDateTime"] = "true";
        properties["level"] = "All";
        // set Adapter
        Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter(properties);
        ILog logger = LogManager.GetLogger(typeof(iText.Kernel.Pdf.PdfReader));
        logger.Error("Testing an error log output", new Exception("The exception message"));
    }
