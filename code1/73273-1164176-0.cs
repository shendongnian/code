                // FIREFOX //
                if (e.Data.GetDataPresent("text/x-moz-url", true)) {
                    HandleFirefoxUrl(e);
                } else if (e.Data.GetDataPresent("text/_moz_htmlcontext", true)) {
                    HandleFirefoxSnippet(e);
                    // IE //
                } else if (e.Data.GetDataPresent("UntrustedDragDrop", false)) {
                    HandleIELink(e);
                } else if (e.Data.GetDataPresent("UniformResourceLocatorW", false)) {
                    HandleIEPage(e);
                } else if (e.Data.GetDataPresent(DataFormats.FileDrop, true)) { //FILES
                    Array droppedFiles = (Array)e.Data.GetData(DataFormats.FileDrop);
                    HandleFiles(droppedFiles);
                } else if (e.Data.GetDataPresent(DataFormats.Bitmap, true)) { // BITMAP
                    Bitmap image = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap);
                    HandleBitmap(image);
                } else if (e.Data.GetDataPresent(DataFormats.Html, true)) { // HTML
                    String pastedHtml = (string)e.Data.GetData(DataFormats.Html);
                    HandleHtml(pastedHtml);
                } else if (e.Data.GetDataPresent(DataFormats.CommaSeparatedValue, true)) { // CSV
                    MemoryStream memstr = (MemoryStream)e.Data.GetData("Csv");
                    StreamReader streamreader = new StreamReader(memstr);
                    String pastedCSV = streamreader.ReadToEnd();
                    HandleCSV(pastedCSV);
                    //  } else if (e.Data.GetDataPresent(DataFormats.Tiff, true)) {
                    //  } else if (e.Data.GetDataPresent(DataFormats.WaveAudio, true)) {
                } else if (e.Data.GetDataPresent(DataFormats.Text, true)) { //TEXT
                    String droppedText = e.Data.GetData(DataFormats.Text).ToString();
                    HandleText(droppedText);
                [else if .....]
                } else { // UNKNOWN
                    Debug.WriteLine("unknown dropped format");
                }
