    var playback = midiFile.GetPlayback(outputDevice);
    
    // You can even loop playback and speed it up
    playback.Loop = true;
    playback.Speed = 2.0;
    
    playback.Start();
    
    // ...
    
    playback.Stop();
    
    // ...
    
    playback.Dispose();
    outputDevice.Dispose();
