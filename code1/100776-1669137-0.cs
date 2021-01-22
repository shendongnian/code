    AudioDevice device = new AudioDevice();
    OutputStream tone1a = device.CreateTone(697);  // part A of DTMF for "1" button
    OutputStream tone1b = device.CreateTone(1209); // part B
    tone1a.Volume = 0.25f;
    tone1b.Volume = 0.25f;
    tone1a.Play();
    tone1b.Play();
    Thread.Sleep(2000);
    // when tone1a stops, you can easily tell that the tone was indeed DTMF
    tone1a.Stop();  
