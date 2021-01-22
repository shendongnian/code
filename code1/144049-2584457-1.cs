        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < LabelExtensions._References.Count; i++)
            {
                var wr = LabelExtensions._References[i];
                sb.AppendLine(i + " alive: " + wr.IsAlive);
            }
            label2.Text = sb.ToString();
        }
