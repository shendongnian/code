    static void Main(string[] args) {
        GenerateXmlDelegate worker = new GenerateXmlDelegate(GenerateMainXml);
        IAsyncResult result = worker.BeginInvoke(GenerateXmlComplete, null);
    }
    private static void GenerateXmlComplete(IAsyncResult result) {
        AsyncResult realResult = result as AsyncResult;
        GenerateXmlDelegate worker = result.AsyncDelegate as GenerateXmlDelegate;
        worker.EndInvoke();
    }
