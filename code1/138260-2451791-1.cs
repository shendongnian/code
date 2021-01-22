    public class YourProgram
    {
        private SoundPlayer player;
        void Play()
        {
           player = new SoundPlayer(@"c:\whatever.wac");
           player.Play();
        }
    }
