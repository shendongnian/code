    public class FastForward : MediaPlayerStates
    {
      public FastForward
      {
          Console.WriteLine("In FastForwardState");
      }
      public override void FastForwardButtonPressed(MediaPlayer player)
      {
                implement guard/action  (=> action="playingSpeed * 2")
      }
      public override void PlayButtonPressed(MediaPlayer player)
      {
                implement guard/action  (=> action="playingSpeed * 2")
      }
    }
    public class PlayingMediaFile : MediaPlayerStates
    {
      public PlayingMediaFile
      {
          Console.WriteLine("In PlayingMediaFileState");
      }
      public override void FastForwardButtonPressed(MediaPlayer player)
      {
                throw new NotImplementedException();
      }
      public override void PlayButtonPressed(MediaPlayer player)
      {
                throw new NotImplementedException();
      }
    }
