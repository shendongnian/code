    string[] files = null;
    TestUploaderWebService.Service1 proxy = null;
    bool success = false;
    try
    {
        proxy = new TestUploaderWebService.Service1();
        files = proxy.GetFileListOnWebServer();
        proxy.Close();
        success = true;
    }
    finally
    {
        if (!success)
        {
            proxy.Abort();
        }
    }
