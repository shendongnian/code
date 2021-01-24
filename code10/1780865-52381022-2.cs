     //If file does not exists, Create a new file and log the result.
                if (!File.Exists(accessiblityTestFileLocation))
                {
                    File.Create(accessiblityTestFileLocation).Dispose();
                    LogResult ();
                }
                //If file exists, Log the result into file.
                else if (File.Exists(accessiblityTestFileLocation))
                {
                    LogResult ();
                }
