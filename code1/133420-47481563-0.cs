        public List<string>  InstalledPrinters
        {
            get
            {
                return (from PrintQueue printer in new LocalPrintServer().GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local,
                    EnumeratedPrintQueueTypes.Connections }).ToList()
                        select printer.Name).ToList(); 
            } 
        }
