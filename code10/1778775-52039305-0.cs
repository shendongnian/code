    private void button1_Click(object sender, EventArgs e)
        {
            List<ProcessStartInfo> startInfos = new List<ProcessStartInfo>();
            if (checkedListBox1.GetItemChecked(0))
            {
                startInfos.Add(new ProcessStartInfo("notepad.exe"));
            }
            if (checkedListBox1.GetItemChecked(1))
            {
                startInfos.Add(new ProcessStartInfo("calc.exe"));
            }
            if (checkedListBox1.GetItemChecked(2))
            {
                startInfos.Add(new ProcessStartInfo("explorer.exe"));
            }
            foreach (var startInfo in startInfos)
            {
                Process.Start(startInfo);
            }
        }
