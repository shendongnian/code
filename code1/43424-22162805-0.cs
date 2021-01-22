    Using System.Printing
    
     var server = new PrintServer();
                var queues = server.GetPrintQueues(new[] { EnumeratedPrintQueueTypes.Local, EnumeratedPrintQueueTypes.Connections });
                foreach (var queue in queues)
                {
                    string printerName = queue.Name;
                    string printerPort = queue.QueuePort.Name;
                 }
           
