    class Foo
    {
        Process proc;
        private void button2_Click(object sender, EventArgs e)
        {
            Process proc;
            if (this.proc != null)
            {
                this.proc.CloseMainWindow();
                this.proc.Close();
            }
            FileName = FetchFile();
            proc = Process.Start(FileName);
        }
    }
