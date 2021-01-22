            var clam = new ClamClient("localhost", 3310);
            var scanResult = clam.ScanFileOnServerAsync("C:\\test.txt"); //any file you would like!
            switch (scanResult.Result.Result)
            {
                case ClamScanResults.Clean:
                    Console.WriteLine("The file is clean!");
                    break;
                case ClamScanResults.VirusDetected:
                    Console.WriteLine("Virus Found!");
                    Console.WriteLine("Virus name: {0}", scanResult.Result.InfectedFiles[0].FileName);
                    break;
                case ClamScanResults.Error:
                    Console.WriteLine("Woah an error occured! Error: {0}", scanResult.Result.RawResult);
                    break;
            }
