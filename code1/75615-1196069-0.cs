    private void button1_Click(object sender, EventArgs e)
    {
        // Starts beep on background thread
        Thread beepThread = new Thread(new ThreadStart(PlayBeep));
        beepThread.IsBackground = true;
        beepThread.Start();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        // Terminates beep from main thread
        Console.Beep(1000, 1);
    }
    private void PlayBeep()
    {
        // Play 1000 Hz for 5 seconds
        Console.Beep(1000, 5000);
    }
