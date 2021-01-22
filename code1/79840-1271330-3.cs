    DialogResult dia = MessageBox.Show("Wanna continue?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    if (dia == DialogResult.Yes)
    {
        StringBuilder logMsg = new StringBuilder();
        logMsg.Append("Name Surname:" + text1.Text + text2.Text + Environment.NewLine);
        logMsg.Append("Other:" + text3.Text + text4.Text + Environment.NewLine);
        logMsg.Append("Money:" + textBox1.Text + " TL." + Environment.NewLine);
        logMsg.Append("*************************************" + Environment.NewLine);
        LogProvider.Logging.AddLog(logMsg.ToString());
    } else
    {
        return;
    }
