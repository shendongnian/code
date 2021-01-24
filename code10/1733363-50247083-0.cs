     private void workerextract_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            {
                try
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        di = new DirectoryInfo(txtQueryfolder.Text);
                    });
                        files = di.GetFiles("*.sql").Count();
                        currentfile = 0;
                    foreach (FileInfo fi in di.GetFiles("*.sql"))
                    {
                        // Open the text file using a stream reader.
                        using (StreamReader sr = new StreamReader(fi.FullName))
                        {
                            // Read the stream to a string, and write the string to the console.
                            string line = sr.ReadToEnd();
                            this.Dispatcher.Invoke(() =>
                            {
                            //System.Windows.MessageBox.Show(line);
                            ExtractToCSV(line, System.IO.Path.GetFileNameWithoutExtension(fi.Name));
                            });
                            currentfile++;
                        }
                        int percentage = (currentfile + 1) * 100 / files;
                        workerextract.ReportProgress(percentage);
                    }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
