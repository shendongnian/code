        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            var dlg = new Func<string>(GetText);
            string value = (string)this.Invoke(dlg);
        }
        private string GetText() {
            return textBox1.Text;
        }
