            StringBuilder strb = new StringBuilder();
       
    private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                string line=lines[i];
                list.Add(line);
            }
          
            foreach (string s in list)
            {
                strb.Append(s);
            }
            txtText.Text = strb.ToString();
        }
