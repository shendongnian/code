    private int counter = 0;
        private string[] MyDirectories = Directory.GetDirectories("C:\\");
        private void ScanButton_Click(object sender, EventArgs e)
        {
            Thread MonitorSpeech = new Thread(() => ScanFiles());
            MonitorSpeech.Start();
        }
        private void ScanFiles()
        {
            string CurrentDirectory = string.Empty;
            while (counter < MyDirectories.Length)
            {
                try
                {
                    GetDirectories();
                    CurrentDirectory = MyDirectories[counter];
                }
                catch
                {
                    if (!this.IsDisposed)
                    {
                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Access Denied to : " + CurrentDirectory); });
                    }
                }
            }
        }
        private void GetDirectories()
        {
            foreach (string directory in MyDirectories)
            {
                GetFiles(directory);
            }
        }
        private void GetFiles(string directory)
        {
            try
            {
                foreach (string file in Directory.GetFiles(directory, "*"))
                {
                    listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(file); });
                }
            }
            catch
            {
                listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add("Access Denied to : " + directory); });
            }
        }
