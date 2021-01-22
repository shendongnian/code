    private ReadOnlyCollection<string> ExtractArchive(string varPathToFile, string varDestinationDirectory) {
            ReadOnlyCollection<string> readOnlyArchiveFilenames;
            ReadOnlyCollection<string> readOnlyVolumeFilenames;
            varExtractionFinished = false;
            varExtractionFailed = false;
            SevenZipExtractor.SetLibraryPath(sevenZipDll);
            string fileName = "";
            string directory = "";
            Invoke(new SetNoArgsDelegate(() => {
                                             fileName = varPathToFile;
                                             directory = varDestinationDirectory;
                                         }));
            using (SevenZipExtractor extr = new SevenZipExtractor(fileName)) {
                //string[] test = extr.ArchiveFileNames.
                        
                readOnlyArchiveFilenames = extr.ArchiveFileNames;
                readOnlyVolumeFilenames = extr.VolumeFileNames;
                //foreach (string dinosaur in readOnlyDinosaurs) {
                //MessageBox.Show(dinosaur);
                // }
                //foreach (string dinosaur in readOnlyDinosaurs1) {
                // // MessageBox.Show(dinosaur);
                // }
                try {
                extr.Extracting += extr_Extracting;
                extr.FileExtractionStarted += extr_FileExtractionStarted;
                extr.FileExists += extr_FileExists;
                extr.ExtractionFinished += extr_ExtractionFinished;
        
                    extr.ExtractArchive(directory);
                } catch (FileNotFoundException error) {
                    if (varExtractionCancel) {
                        LogBoxTextAdd("[EXTRACTION WAS CANCELED]");
                    } else {
                        MessageBox.Show(error.ToString(), "Error with extraction");
                        varExtractionFailed = true;
                    }
                }
            }
            varExtractionFinished = true;
            return readOnlyVolumeFilenames;
        }
      private void extr_FileExists(object sender, FileOverwriteEventArgs e) {
            listViewLogFile.Invoke(new SetOverwriteDelegate((args) => LogBoxTextAdd(String.Format("Warning: \"{0}\" already exists; overwritten\r\n", args.FileName))), e);
        }
        private void extr_FileExtractionStarted(object sender, FileInfoEventArgs e) {
            listViewLogFile.Invoke(new SetInfoDelegate((args) => LogBoxTextAdd(String.Format("Extracting \"{0}\"", args.FileInfo.FileName))), e);
        }
        private void extr_Extracting(object sender, ProgressEventArgs e) {
            progressBarCurrentExtract.Invoke(new SetProgressDelegate((args) => progressBarCurrentExtract.Increment(args.PercentDelta)), e);
        }
        private void extr_ExtractionFinished(object sender, EventArgs e) {
            Invoke(new SetNoArgsDelegate(() => {
                                             //pb_ExtractWork.Style = ProgressBarStyle.Blocks;
                                             progressBarCurrentExtract.Value = 0;
                                             varExtractionFinished = true;
                                             //l_ExtractProgress.Text = "Finished";
                                         }));
        }
