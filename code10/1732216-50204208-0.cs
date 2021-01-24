        Process[] processes = Process.GetProcessesByName(listBox1.SelectedItem.ToString());
        foreach (Process process in processes)
        {
            process.Kill();
        }
