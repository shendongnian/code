      private void btnVar_Click(object sender, EventArgs e)
        {
            Stopwatch obj = new Stopwatch();
            obj.Start();
            var test = "Test";
            test.GetType();
            obj.Stop();
            lblResults.Text = obj.Elapsed.ToString();
        }
        private void btnString_Click(object sender, EventArgs e)
        {
            Stopwatch obj = new Stopwatch();
            obj.Start();
            string test = "Test";
            obj.Stop();
            lblResults.Text = obj.Elapsed.ToString();
        }
