    private void checkBox1_CheckedChanged(object sender, EventArgs e) {
        //do a check if the process is still alive or not.
        if (cvarDataServiceProcess.HasExited) {
            MessageBox.Show("terminated");
        }
        else {
            ProcessWindowStyle state = cvarDataServiceProcess.StartInfo.WindowStyle;
            if (state == ProcessWindowStyle.Hidden)
                cvarDataServiceProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            else if (state == ProcessWindowStyle.Normal)
                cvarDataServiceProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        }
    }
