        private void DirectoryCountEnumTest(string sourceDirName)
        {
            // Get the subdirectories for the specified directory.
            long dataSize = 0;
            long fileCount = 0;
            string prevText = richTextBox1.Text;
            if (Directory.Exists(sourceDirName))
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                foreach (FileInfo file in dir.EnumerateFiles("*", SearchOption.AllDirectories))
                {
                    fileCount++;
                    try
                    {
                        dataSize += file.Length;
                        richTextBox1.Text = prevText + ("\nCounting size: " + dataSize.ToString());
                    }
                    catch (Exception e)
                    {
                        richTextBox1.AppendText("\n" + e.Message);
                    }
                }
                richTextBox1.AppendText("\n files:" + fileCount.ToString());
            }
        }
