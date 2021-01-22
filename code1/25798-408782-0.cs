        private void button1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = @"C:\Windows\Media\chimes.wav";
            player.Play();
        }
