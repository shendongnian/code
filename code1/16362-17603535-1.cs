    string process = "notepad";
    if (Process.GetProcessesByName(process).Length == 0)
    {
        MessageBox.Show("Working");
    }
    else
    {
        MessageBox.Show("Not Working");
    }
