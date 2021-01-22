       public class TestPlayers
        {
            public void PlayMedia()
            {
                MusicPlayer musicPlayer = new MusicPlayer();
                musicPlayer.Play(new Mp3());
                musicPlayer.Play(new MPEG());
            }       
        }
