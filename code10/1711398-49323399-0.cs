    async void button1_Click(object sender, EventArgs e)
    {
        ...
        var player = new SoundPlayer { SoundLocation = @"C:\Wer wird Behindert\winsound.wav" };
        button1.Enabled = false; // prevent clicks while sound is played
        await Task.Run(() => player.PlaySync()); // next line will execute after sound playing is finished
        button1.Enabled = true;
        Frage.Text = "Was ist besser?";
        ...
    }
