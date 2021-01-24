    if (result == 1)
                {
                    Console.WriteLine("Downloading The Trainer!", option);
                    string remoteUri = "https://nukleus.XXX.com/dashboard/download/Trainer/XXXVIP.CETRAINER";
                    string fileName = "XXXVIP.CETRAINER";
                    WebClient myWebClient = new WebClient();                    Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, remoteUri);
                    myWebClient.DownloadFile(remoteUri, fileName);
                    Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, remoteUri);
                }
