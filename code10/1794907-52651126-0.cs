    private bool appendLine(string line2Write, string fileName)
    {
        try
        {
            StreamWriter tw;
            using (tw = File.AppendText(fileName))
            {
                tw.WriteLine(line2Write);
            }
        }
        catch (Exception ex)
        {
            DialogResult result = MessageBox.Show("Unable to write to: " + fileName + "\r\n" + ex.ToString() + "\r\n OK to retry", "File Sysytem Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (result == DialogResult.Cancel)
            {
                return false;
            }
        }
        return true;
    }
