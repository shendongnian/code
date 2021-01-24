    void commandCreation(object sender, EventArgs e)
        {
        var command = new LightCommand(); //  <== because you declare it HERE
        command.On = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ILocalHueClient.SendCommandAsync(command); // ^^ command is out of scope HERE.
        }
