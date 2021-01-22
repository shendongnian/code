        // get available printers
        LocalPrintServer printServer = new LocalPrintServer();
        PrintQueue defaultPrintQueue = printServer.DefaultPrintQueue;
        // get all printers installed (from the users perspective)he t
        var printerNames = PrinterSettings.InstalledPrinters;
        var availablePrinters = printerNames.Cast<string>().Select(printerName => 
        {
            var match = Regex.Match(printerName, @"(?<machine>\\\\.*?)\\(?<queue>.*)");
            PrintQueue queue;
            if (match.Success)
            {
                queue = new PrintServer(match.Groups["machine"].Value).GetPrintQueue(match.Groups["queue"].Value);
            }
            else
            {
                queue = printServer.GetPrintQueue(printerName);
            }
            var capabilities = queue.GetPrintCapabilities();
            return new AvailablePrinterInfo()
            {
                Name = printerName,
                Default = queue.FullName == defaultPrintQueue.FullName,
                Duplex = capabilities.DuplexingCapability.Contains(Duplexing.TwoSidedLongEdge),
                Color = capabilities.OutputColorCapability.Contains(OutputColor.Color)
            };
        }).ToArray();
        DefaultPrinter = AvailablePrinters.SingleOrDefault(x => x.Default);
