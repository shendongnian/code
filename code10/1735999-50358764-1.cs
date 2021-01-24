    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        System.IO.File.WriteAllText("D:\SomePath\CloseReason.txt", e.CloseReason.ToString());
        if (e.CloseReason == CloseReason.UserClosing) e.Cancel = true;
    }
