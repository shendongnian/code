            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter((Stream)File.Open(@"C:\DefaultSettings.txt", FileMode.CreateNew));
                sw.WriteLine("Test");
            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("already exists"))
                {
                    statusbar1.Text = "File already exists";
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            finally
            {
                if (sw != null)
                { sw.Close(); }
            }
