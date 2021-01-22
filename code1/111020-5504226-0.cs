        private void button1_Click(object sender, EventArgs e) {
            Thread t1 = new Thread(DoIt);
            Thread t2 = new Thread(DoIt);
            t1.Start("a");
            t2.Start("b");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
        private void DoIt(object p) {
            using (FileStream fs = new FileStream(FileName, FileMode.Open, FileSystemRights.AppendData,
                FileShare.Write, 4096, FileOptions.None)) {
                using (StreamWriter writer = new StreamWriter(fs)) {
                    writer.AutoFlush = true;
                    for (int i = 0; i < 20; ++i)
                        writer.WriteLine("{0}: {1:D3} {2:o} hello", p, i, DateTime.Now);
                }
            }
        }
