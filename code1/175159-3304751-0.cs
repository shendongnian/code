    interface IMedia 
    {
      void Play();
      void Stop();
    }
    class Video : IMedia
    {
      public Audio Audio; /// aka child
      public void Play() { }
      public void Stop() { }
    }
    class Audio : IMedia
    {
      public Video Video; /// aka parent...questionable unless Audio 
                          /// always has a parent Video
      public void Play() { }
      public void Stop() { }
    }
    private void PlayAnyMedia(IMedia media) /// Write against an interface
    {
      media.Play();
    }
