     private List<string> wavlist = new List<string>();
     wavlist.Add("c:\\1.wav");
     wavlist.Add("c:\\2.wav");
     foreach(string file  in wavlist)
     {
          AudioFileReader audio = new AudioFileReader(file);
          audio.Volume = 1;
          IWavePlayer player = new WaveOut(WaveCallbackInfo.FunctionCallback());
          player.Init(audio);
          player.Play();
          System.Threading.Thread.Sleep(audio.TotalTime);
          player.Stop();
          player.Dispose();
          audio.Dispose();
          player = null;
          audio = null;
      }
