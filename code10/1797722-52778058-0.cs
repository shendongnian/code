    OpenFileDialog ofdChoos = new OpenFileDialog();
                    if (ofdChoos.ShowDialog() == DialogResult.OK)
                    {
                        System.Net.WebClient Client = new System.Net.WebClient();
                        var sourceString = ofdChoos.FileName.Replace(@"\", @"/");
                        var source = @"" + sourceString;
    
                        string exts = Path.GetExtension(source);
                        string ext  = exts.Replace(@".", string.Empty);
                        Client.Headers.Add("Content-Type", ext);
    
                        var result = Client.UploadFile("https://zff.com/upload.php", "POST", @source);
                        string s = System.Text.Encoding.UTF8.GetString(result, 0, result.Length);
                        MessageBox.Show(s);
                    }
