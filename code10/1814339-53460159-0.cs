    void Awake()
    {
        //Enable Callback on the main Thread
        UnityThread.initUnityThread();
    }
    public void LoadSong(string musicPath)
    {
        ThreadPool.QueueUserWorkItem(delegate
        {
            //Set title of song
            songTitle = Path.GetFileNameWithoutExtension(musicPath);
            if (songTitle != currentlyPlaying && songTitle != lastPlayedTitle)
            {
                //Parse the file with NAudio
                aud = new AudioFileReader(musicPath);
                //Create an empty float to fill with song data
                AudioData = new float[aud.Length];
                //Read the file and fill the float
                aud.Read(AudioData, 0, (int)aud.Length);
                //Now, create the clip on the main Thread and also play it
                UnityThread.executeInUpdate(() =>
                {
                    //Create a clip file the size needed to collect the sound data
                    craftClip = AudioClip.Create(songTitle, (int)aud.Length, aud.WaveFormat.Channels, aud.WaveFormat.SampleRate, false);
                    //Fill the file with the sound data
                    craftClip.SetData(AudioData, 0);
                    if (craftClip.isReadyToPlay)
                    {
                        playMusic(craftClip, songTitle);
                        /*Disposing on main thread may also introduce freezing so do that in a Thread too*/
                        ThreadPool.QueueUserWorkItem(delegate { aud.Dispose(); });
                    }
                });
            }
            else
            {
                UnityThread.executeInUpdate(() =>
                {
                    playMusic(lastPlayedAudioFile, lastPlayedTitle);
                });
            }
        });
    }
