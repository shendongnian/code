        public void PrintHtml(string htmlPath, string printerDevice)
        {
            if (!string.IsNullOrEmpty(printerDevice))
                SetAsDefaultPrinter(printerDevice);
            Task.Factory.StartNew(() => PrintOnStaThread(htmlPath), CancellationToken.None, TaskCreationOptions.None, _sta).Wait();
        }
