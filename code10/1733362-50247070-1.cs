    private void workerextract_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        string queryFolder = e.Argument.ToString();
        try
        {
            DirectoryInfo di = new DirectoryInfo(queryFolder);
            files = di.GetFiles("*.sql").Count();
            currentfile = 0;
            foreach (FileInfo fi in di.GetFiles("*.sql"))
            {
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(fi.FullName))
                {
                    // Read the stream to a string, and write the string to the console.
                    string line = sr.ReadToEnd();
                    //System.Windows.MessageBox.Show(line);
                    // ExtractToCSV shouldn't access to a UI object.
                    ExtractToCSV(line, System.IO.Path.GetFileNameWithoutExtension(fi.Name));
                    currentfile++;
                }
                int percentage = (currentfile + 1) * 100 / files;
                workerextract.ReportProgress(percentage);
            }
        }
        catch (Exception ex)
        {
            // Don't use MessageBox in a thread different from the UI one. Just set the result (e.Result) and get that in the RunWorkerCompleted event.
            // System.Windows.MessageBox.Show(ex.Message);
        }
    }
