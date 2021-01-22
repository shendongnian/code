    string newText = "";
    try
    {
        //populate the content for newText
        using (StreamWriter sw = File.AppendText(LOG_FILE))
        {
            sw.Write(newText);
        }
    }
    catch (IOException ex)
    {
        MessageBox.Show("Failed to write to log!\n\t" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
