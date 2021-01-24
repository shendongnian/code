    void commandCreation(object sender, EventArgs e)
    {
        var command = new LightCommand(); //  <== because you declare it HERE
        command.On = true;
    }
    private void button1_Click(object sender, EventArgs e)
    {
            ILocalHueClient.SendCommandAsync(command); // ^^ command is out of scope HERE.
            // Also, it seems you are calling SendCommandAsync llike static function.
            // It may be that you need to cal this on the 'client' instance,
            // which you should make a class field:
            client.SendCommandAsync(command);
    }
