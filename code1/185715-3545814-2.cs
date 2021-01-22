    private void button3_Click(object sender, EventArgs e)
    {
        String value = button3.Text;
        if (value == "Pause")
        {
            CommandString = "pause mp3file";
            mciSendString(CommandString, null, 0, 0);
            Status = true;
            button3.Text = "Resume";
        }
        if (value == "Resume")
        {   
            CommandString = "resume mp3file";
            mciSendString(CommandString, null, 0, 0);
            buton3.Text = "Pause"; // As mentioned before, this is required too.
        }
    }
