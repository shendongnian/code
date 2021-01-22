    class Program {
        private delegate void GenerateXmlDelegate();
        static void Main(string[] args) {
            GenerateXmlDelegate worker = new GenerateXmlDelegate(GenerateMainXml);
            IAsyncResult result = worker.BeginInvoke(delegate {
                try {
                    worker.EndInvoke();
                } catch(...) { ... }
            }, null);
        }
        private static void GenerateMainXml() {
            Thread.Sleep(10000);
            Console.WriteLine("GenerateMainXml Called by delegate");
        }
    }
