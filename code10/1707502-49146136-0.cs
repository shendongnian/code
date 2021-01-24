       if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                         tw.WriteLine(txtDateTym.Text + " , " + txtKQ.Text);
                      
                    }
    
                }
