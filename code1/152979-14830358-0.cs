        using (FileStream fs = new FileStream(Application.StartupPath + @"\File.txt",FileMode.Create, FileAccess.ReadWrite))
                {
                    fs.Close();
                }
                using (StreamWriter sw = new StreamWriter(Application.StartupPath + @"\File.txt"))
                {
                    sw.WriteLine("bla bla bla");
                    sw.WriteLine("bla bla bla");
                    sw.Close();
                }
            }
            catch (IOException err)
            {
                MessageBox.Show(err.Message);
            }
